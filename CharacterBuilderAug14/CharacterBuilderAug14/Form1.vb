Public Class CB
    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        For Each ctrl As Control In Me.GroupBox4.Controls
            If TypeOf ctrl Is CheckBox Then
                AddHandler (DirectCast(ctrl, CheckBox).CheckedChanged), AddressOf Check_Clicked
            End If
            ctrl = Me.GetNextControl(ctrl, True)
        Next
    End Sub

    Sub Check_Clicked(sender As Object, e As EventArgs)
        Dim s As CheckBox
        s = sender 'Downcast from object to checkbox
        If s.Checked = True Then 'if we checked a box, we have one less skill available
            Me.count.Text = CInt(Me.count.Text) - 1
        Else 'but if we unchecked, we can pick one more.
            Me.count.Text = CInt(Me.count.Text) + 1
        End If
        'check for homebrew
        check_homebrew()
    End Sub

    Sub check_homebrew()
        If CInt(Me.count.Text) < 0 Then
            homebrewed.Checked = True
        Else
            homebrewed.Checked = False
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Me.sizeBenefit.Text = "-1 Damage, +1 Reflex, +5 Stealth"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Me.sizeBenefit.Text = "No penalties or bonuses due to size"
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Me.sizeBenefit.Text = "-1 Reflex, +1 damage die, -5 stealth"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddNewSkill.Show()
    End Sub

    Private Sub CB_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheckBox25_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim g As Graphics
        Dim sText As String
        Dim iX As Integer
        Dim iY As Integer
        Dim sizeText As SizeF
        Dim ctlTab As TabControl

        ctlTab = CType(sender, TabControl)

        g = e.Graphics

        sText = ctlTab.TabPages(e.Index).Text
        sizeText = g.MeasureString(sText, ctlTab.Font)
        iX = e.Bounds.Left + 6
        iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2
        g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY)
    End Sub
End Class
