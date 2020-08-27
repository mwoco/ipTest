Option Explicit On
Option Strict On

Imports System.ComponentModel
Imports System.Net.Sockets
Imports System.Text


Public Class mainForm
    Delegate Sub appendLogDelegate(ByVal Text As String)

    Dim udpRx As UdpClient
    Dim tcpRx As TcpListener
    Public udpRxThread As System.Threading.Thread
    Public tcpRxThread As System.Threading.Thread


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rxAddress.Text = System.Net.Dns.GetHostName & " (localhost)"
        appendLog("local addresses:" & vbCrLf & " - " & String.Join(vbCrLf & " - ", System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).AddressList().ToList))
        appendLog("double-click log area to clear it")
    End Sub


    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.Save()
    End Sub


    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        End
    End Sub


    Private Sub appendLog(logText As String)
        logArea.Text = DateTime.Now.ToString("HH:mm:ss - ") & logText & vbCrLf & logArea.Text
    End Sub


    Private Sub logArea_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles logArea.MouseDoubleClick
        logArea.Text = ""
        appendLog("log area cleared")
    End Sub


    Private Sub port_ValueChanged(sender As Object, e As EventArgs) Handles rxPort.ValueChanged
        appendLog("UDP/TCP server port: " & rxPort.Value)
        updateUdpServer()
        updateTcpServer()
    End Sub


    Private Sub updateUdpServer()
        If (udpRx IsNot Nothing) Then udpRx.Close()
        If (udpRxThread IsNot Nothing) Then udpRxThread.Abort()

        Try
            udpRx = New UdpClient(AddressFamily.InterNetworkV6)
            udpRx.Client.DualMode = True
            udpRx.Client.Bind(New Net.IPEndPoint(Net.IPAddress.IPv6Any, CInt(rxPort.Value)))
            udpRxThread = New System.Threading.Thread(AddressOf udpServer)
            udpRxThread.Start()
        Catch ex As Exception
            appendLog("Rx/UDP ERROR (Port " & rxPort.Value & "):" & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub updateTcpServer()
        If (tcpRx IsNot Nothing) Then tcpRx.Stop()
        If (tcpRxThread IsNot Nothing) Then tcpRxThread.Abort()

        Try
            tcpRx = New TcpListener(New Net.IPEndPoint(Net.IPAddress.IPv6Any, CInt(rxPort.Value)))
            tcpRx.Server.DualMode = True
            tcpRx.Start()
            tcpRxThread = New System.Threading.Thread(AddressOf tcpServer)
            tcpRxThread.Start()
        Catch ex As Exception
            appendLog("Rx/TCP ERROR (Port " & rxPort.Value & "):" & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub sendData_Click(sender As Object, e As EventArgs) Handles sendData.Click
        txAddress.Text = Trim(txAddress.Text)
        txMessage.Text = Trim(txMessage.Text)
        If (txMessage.Text = "") Then txMessage.Text = "TestData"

        If txMode.Text.Contains("UDP") Then sendUdpMessage()
        If txMode.Text.Contains("TCP") Then sendTcpMessage()
    End Sub


    Private Sub sendUdpMessage()
        Try
            Dim udpTx As UdpClient = New UdpClient(txAddress.Text, CInt(txPort.Value))
            With udpTx
                Dim sendBytes As Byte() = Encoding.ASCII.GetBytes(txMessage.Text & " -- " & DateTime.Now.ToString("HH:mm:ss"))
                .Send(sendBytes, sendBytes.Length)
                appendLog("Tx/UDP -> " & txAddress.Text & " / [" & CType(.Client.RemoteEndPoint, System.Net.IPEndPoint).Address.ToString & "]:" & txPort.Value.ToString & " :: [" & Encoding.ASCII.GetString(sendBytes) & "]")
                .Close()
            End With
        Catch ex As Exception
            appendLog("Tx/UDP ERROR:" & vbCrLf & ex.Message)
        End Try
    End Sub


    Private Sub sendTcpMessage()
        Me.Cursor = Cursors.WaitCursor

        Try
            Dim tcpTx As TcpClient = New TcpClient(txAddress.Text, CInt(txPort.Value))
            With tcpTx
                Dim sendBytes As Byte() = Encoding.ASCII.GetBytes(txMessage.Text & " -- " & DateTime.Now.ToString("HH:mm:ss"))
                Dim stream As NetworkStream = .GetStream()
                stream.Write(sendBytes, 0, sendBytes.Length)
                stream.Flush()
                appendLog("Tx/TCP -> " & txAddress.Text & " / [" & CType(.Client.RemoteEndPoint, System.Net.IPEndPoint).Address.ToString & "]:" & txPort.Value.ToString & " :: [" & Encoding.ASCII.GetString(sendBytes) & "]")
                .Close()
            End With
        Catch ex As Exception
            appendLog("Tx/TCP ERROR:" & vbCrLf & ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub


    Public Sub udpServer()
        Dim udpEndPoint As New System.Net.IPEndPoint(System.Net.IPAddress.IPv6Any, 0)

        While (True)
            Try
                Dim receiveBytes As [Byte]() = udpRx.Receive(udpEndPoint)
                Me.Invoke(New appendLogDelegate(AddressOf appendLog), "Rx/UDP <- [" & udpEndPoint.Address.ToString & "]:" & udpEndPoint.Port.ToString & " :: [" & Encoding.ASCII.GetString(receiveBytes) & "]")
            Catch ex As System.Threading.ThreadAbortException
                Exit Sub
            Catch ex As Exception
                ' do nothing / try again
            End Try
        End While
    End Sub


    Public Sub tcpServer()
        Dim receiveBytes(128) As Byte

        While (True)
            Try
                Dim client As TcpClient = tcpRx.AcceptTcpClient
                With client
                    Dim tcpEndPoint As System.Net.IPEndPoint = CType(.Client.RemoteEndPoint, System.Net.IPEndPoint)
                    Dim stream As NetworkStream = .GetStream()
                    Dim byteCount As Int32 = stream.Read(receiveBytes, 0, receiveBytes.Length)
                    .Close()
                    Me.Invoke(New appendLogDelegate(AddressOf appendLog), "Rx/TCP <- [" & tcpEndPoint.Address.ToString & "]:" & tcpEndPoint.Port.ToString & " :: [" & Encoding.ASCII.GetString(receiveBytes, 0, byteCount) & "]")
                End With
            Catch ex As System.Threading.ThreadAbortException
                Exit Sub
            Catch ex As Exception
                ' do nothing / try again
            End Try
        End While
    End Sub


End Class
