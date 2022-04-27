Option Strict On
Public Class Form1
    Private Enum T As Integer
        fhour
        fminute
        fsecond
    End Enum
    Private G1 As Graphics
    Private Pen1 As Pen = New Pen(Color.Black, 1)
    Private Pen2 As Pen = New Pen(Color.Black, 2)
    Private Pen3 As Pen = New Pen(Color.Black, 5)
    Private PenA As Pen = New Pen(Color.Gray, 1)
    Private PenB As Pen = New Pen(Color.Gray, 2)
    Private PenC As Pen = New Pen(Color.Gray, 5)
    Private times() As String
    Private Const Hto60 As Integer = 5
    Private Const MSto360 As Integer = 6
    Private Const Raund90 As Integer = 90
    Private Const CLong As Integer = 135
    Private Const SLong As Integer = CLong - 5
    Private Const HLong As Integer = CInt(SLong / 2)
    Private Const DLong As Integer = CLong - 4
    Private Const CC As Integer = 12
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer.Start()
        Cleanup()
        Gettime()
        draw()
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        If Not times Is Gettime() Then
            draw()
        End If
    End Sub
    Private Sub draw()
        Cleanup()
        'Clean()
        defult()
        Second(CInt(Gettime(T.fsecond)), Pen1)
        Minute(CInt(Gettime(T.fminute)), Pen2)
        Hour(CInt(Gettime(T.fhour)), Pen3)
        Nowtime()
    End Sub
    Private Sub Cleanup()
        G1 = PictureBox.CreateGraphics
        G1.Clear(Color.Gray)
    End Sub
    Private Sub Clean()
        Second(CInt(times(T.fsecond)), PenA)
        Minute(CInt(times(T.fminute)), PenB)
        Hour(CInt(times(T.fhour)), PenC)
    End Sub

    Private Sub defult()
        G1 = PictureBox.CreateGraphics
        Dim X1 As Double
        Dim X2 As Double
        Dim Y1 As Double
        Dim Y2 As Double
        Dim i As Integer
        Dim angle As Integer
        For i = 0 To CC - 1
            angle = i * Hto60 * MSto360 - Raund90
            X1 = CLong + CLong * Math.Cos(angle * Math.PI / 180)
            Y1 = CLong + CLong * Math.Sin(angle * Math.PI / 180)
            X2 = CLong + DLong * Math.Cos(angle * Math.PI / 180)
            Y2 = CLong + DLong * Math.Sin(angle * Math.PI / 180)
            G1.DrawLine(Pen2, CInt(X1), CInt(Y1), CInt(X2), CInt(Y2))
        Next
    End Sub

    Private Sub Second(ByVal Sec As Integer, ByVal Pen As Pen)
        G1 = PictureBox.CreateGraphics
        Dim X As Double
        Dim Y As Double
        Dim angle As Integer = Sec * MSto360 - Raund90
        X = CLong + SLong * Math.Cos(angle * Math.PI / 180)
        Y = CLong + SLong * Math.Sin(angle * Math.PI / 180)
        G1.DrawLine(Pen, CLong, CLong, CInt(X), CInt(Y))
    End Sub

    Private Sub Minute(ByVal Min As Integer, ByVal Pen As Pen)
        G1 = PictureBox.CreateGraphics
        Dim X As Double
        Dim Y As Double
        Dim angle As Integer = Min * MSto360 - Raund90
        X = CLong + SLong * Math.Cos(angle * Math.PI / 180)
        Y = CLong + SLong * Math.Sin(angle * Math.PI / 180)
        G1.DrawLine(Pen, CLong, CLong, CInt(X), CInt(Y))
    End Sub

    Private Sub Hour(ByVal H As Integer, ByVal Pen As Pen)
        G1 = PictureBox.CreateGraphics
        Dim X As Double
        Dim Y As Double
        Dim angle As Integer = H * MSto360 * Hto60 - Raund90
        X = CLong + HLong * Math.Cos(angle * Math.PI / 180)
        Y = CLong + HLong * Math.Sin(angle * Math.PI / 180)
        G1.DrawLine(Pen, CLong, CLong, CInt(X), CInt(Y))
    End Sub

    Private Sub Nowtime()
        Label.Text = DateTime.Now.ToString
    End Sub

    Private Function Gettime() As String()
        Dim Time As String = DateTime.Now.ToLongTimeString
        Dim Temp(2) As String
        Temp = Time.Split(CChar(":"))
        Gettime = Temp
        times = Temp
    End Function

End Class
