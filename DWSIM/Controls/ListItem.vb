﻿Public Class ListItem

    Public Property ObjectTypeInfo As Type = Nothing

    Private Sub ListItem_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles Me.GiveFeedback
        If DWSIM.App.IsRunningOnMono Then
            e.UseDefaultCursors = True
        Else
            e.UseDefaultCursors = False
            Dim bmp As New Bitmap(Me.Image.Width + 30, Me.Image.Height + 30)
            Me.Image.DrawToBitmap(bmp, New Rectangle(New Drawing.Point(30, 30), bmp.Size))
            bmp.MakeTransparent(Color.White)
            Dim g = Graphics.FromImage(bmp)
            g.CompositingMode = Drawing2D.CompositingMode.SourceOver
            Dim arrow As Bitmap = My.Resources.cursor
            g.DrawImage(arrow, New Drawing.Point(25, 25))
            Dim cur As New Cursor(bmp.GetHicon())
            Cursor.Current = cur
        End If
    End Sub

    Private Sub ListItem_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, lblDescription.MouseDown, lblName.MouseDown, Image.MouseDown
        Me.DoDragDrop(ObjectTypeInfo, DragDropEffects.All)
    End Sub

    Private Sub ListItem_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp, lblDescription.MouseUp, lblName.MouseUp, Image.MouseUp
        'Me.BackColor = Color.White
    End Sub

End Class
