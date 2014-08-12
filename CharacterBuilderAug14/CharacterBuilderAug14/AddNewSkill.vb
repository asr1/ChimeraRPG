Public Class AddNewSkill

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name As String
        name = Me.SkillName.Text
        Me.Hide()
        'If the first blank has been assigned, skip it until we find an open one
        If CB.blank1.Visible = False Then
            CB.blank1.Visible = True
            CB.blank1.Text = name
        ElseIf CB.Blank2.Visible = False Then
            CB.Blank2.Visible = True
            CB.Blank2.Text = name
        ElseIf CB.blank3.Visible = False Then
            CB.blank3.Visible = True
            CB.blank3.Text = name
        ElseIf CB.blank4.Visible = False Then
            CB.blank4.Visible = True
            CB.blank4.Text = name
        ElseIf CB.blank5.Visible = False Then
            CB.blank5.Visible = True
            CB.blank5.Text = name
        End If
    End Sub

    Private Sub AddNewSkill_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
End Class