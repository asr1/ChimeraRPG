Public Class RemoveSkill

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub RemoveSkill_load(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        CustomSkills.Items.Clear()
        CustomSkills.SelectedValue = -1
        If Not CB.blank1.Text = "" Then
            CustomSkills.Items.Add(CB.blank1.Text)
        End If
        If Not CB.Blank2.Text = "" Then
            CustomSkills.Items.Add(CB.Blank2.Text)
        End If
        If Not CB.blank3.Text = "" Then
            CustomSkills.Items.Add(CB.blank3.Text)
        End If
        If Not CB.blank4.Text = "" Then
            CustomSkills.Items.Add(CB.blank4.Text)
        End If
        If Not CB.blank5.Text = "" Then
            CustomSkills.Items.Add(CB.blank5.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not CustomSkills.SelectedIndex = -1 Then
            If CB.blank1.Text = CustomSkills.SelectedItem.ToString Then
                CB.blank1.Text = ""
                CB.blank1.Checked = False
                CB.blank1.Visible = False

            ElseIf CB.Blank2.Text = CustomSkills.SelectedItem.ToString Then
                CB.Blank2.Text = ""
                CB.Blank2.Checked = False
                CB.Blank2.Visible = False

            ElseIf CB.blank3.Text = CustomSkills.SelectedItem.ToString Then
                CB.blank3.Text = ""
                CB.blank3.Checked = False
                CB.blank3.Visible = False

            ElseIf CB.blank4.Text = CustomSkills.SelectedItem.ToString Then
                CB.blank4.Text = ""
                CB.blank4.Checked = False
                CB.blank4.Visible = False

            ElseIf CB.blank5.Text = CustomSkills.SelectedItem.ToString Then
                CB.blank5.Text = ""
                CB.blank5.Checked = False
                CB.blank5.Visible = False
            End If
        End If
        CustomSkills.Items.Clear()
        Me.Hide()
    End Sub

End Class