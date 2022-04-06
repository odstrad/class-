﻿Public Class Form1
    Private m_Previous As System.Nullable(Of Point) = Nothing
    Dim m_shapes As New Collection
    Dim c As Color
    Dim w As Integer
    Dim h As Integer
    Dim type As String
    Dim s1 As Integer
    Dim s2 As Integer



    Private Sub pictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        m_Previous = e.Location
        pictureBox1_MouseMove(sender, e)
    End Sub

    Private Sub pictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If m_Previous IsNot Nothing Then

            Dim d As Object
            d = New Line(PictureBox1.Image, m_Previous, e.Location)
            d.pen = New Pen(c, w)
            d.xspeed = TrackBar3.Value
            If type = "Line" Then
                d = New Line(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
                d.xspeed = TrackBar3.Value
            End If

            If type = "Rectangle" Then
                d = New Rect(PictureBox1.Image, m_Previous, e.Location)
                d.fill = CheckBox2.Checked
                d.pen = New Pen(c, w)
            End If

            If type = "Circle" Then
                d = New circle(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
            End If

            If type = "Poly" Then
                d = New Poly(PictureBox1.Image, m_Previous, e.Location)
                d.pen = New Pen(c, w)
            End If
            If type = "picture" Then
                d = New pic(PictureBox1.Image, m_Previous, e.Location)
                d.picture = PictureBox2.Image
            End If
            m_shapes.Add(d)
            PictureBox1.Invalidate()
            m_Previous = e.Location
        End If
    End Sub

    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        m_Previous = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PictureBox1.Image Is Nothing Then
            Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
            End Using
            PictureBox1.Image = bmp
        End If

    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        For Each s As Object In m_shapes
            s.Draw()
            If CheckBox1.Checked = True Then
                Refresh()
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        c = ColorDialog1.Color
        Button1.BackColor = c

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        c = sender.backcolor
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        c = sender.backcolor
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        w = TrackBar1.Value
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
        End Using
        PictureBox1.Image = bmp
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaveFileDialog1.ShowDialog()
        PictureBox1.Image.Save(SaveFileDialog1.FileName)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        type = "Rectangle"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        type = "Line"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        type = "Circle"
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        type = "Poly"
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        type = "picture"
    End Sub
End Class