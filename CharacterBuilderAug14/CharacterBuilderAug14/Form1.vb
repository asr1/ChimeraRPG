Public Class CB
    Public Const NUM_ATTRIBUTES = 8

    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        'Add this handler to every checkbox in the skills section.
        'Used to count remaining skills
        For Each ctrl As Control In Me.GroupBox4.Controls
            If TypeOf ctrl Is CheckBox Then
                AddHandler (DirectCast(ctrl, CheckBox).CheckedChanged), AddressOf Check_Clicked
            End If
            ctrl = Me.GetNextControl(ctrl, True)
        Next

        'Add this handler to every label in the attributes section
        'Used for drag and drop
        For Each ctrl As Control In Me.AttrGroup.Controls
            If TypeOf ctrl Is Label Then
                AddHandler ctrl.MouseDown, AddressOf LabelMouseDown
            ElseIf TypeOf ctrl Is TextBox Then
                AddHandler ctrl.DragEnter, AddressOf box_DragEnter
                AddHandler ctrl.DragDrop, AddressOf box_DragDrop
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

    Private Sub check_homebrew()
        'If we chose too many skills
        If CInt(Me.count.Text) < 0 Or
            Not legal_attr_avg() Then

            homebrewed.Checked = True
        Else
            homebrewed.Checked = False
        End If
    End Sub

    'Returns true if the attributes have been completed legally or have not been completed
    'Returns false if the attributes have been completed illegally.
    Private Function legal_attr_avg() As Boolean
        If completed_attr() Then
            Dim total As Integer
            total = 0
            For Each ctrl As Control In Me.AttrGroup.Controls
                If TypeOf ctrl Is TextBox Then
                    total = total + CInt(ctrl.Text)
                End If
            Next
            If Not total / NUM_ATTRIBUTES = 20 Then
                Return False
            End If
        End If
        Return True 'We return true if we haven't done attributes
    End Function

    'Returns true if all the attributes have values, false if at least one is blank
    Private Function completed_attr() As Boolean
        For Each ctrl As Control In Me.AttrGroup.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Text = "" Then
                    Return False ' If we haven't set at least one attribute
                End If
            End If
        Next
        Return True
    End Function

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

    Private Sub AttrGroup_Enter(sender As Object, e As EventArgs) Handles AttrGroup.Enter

    End Sub

    'Selected an array of attributes
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        Me.a1.Text = 30
        Me.a2.Text = 30
        Me.a3.Text = 30
        Me.a4.Text = 20
        Me.a5.Text = 20
        Me.a6.Text = 10
        Me.a7.Text = 10
        Me.A8.Text = 10
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        Me.a1.Text = 30
        Me.a2.Text = 30
        Me.a3.Text = 20
        Me.a4.Text = 20
        Me.a5.Text = 20
        Me.a6.Text = 20
        Me.a7.Text = 10
        Me.A8.Text = 10
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        Me.a1.Text = 20
        Me.a2.Text = 20
        Me.a3.Text = 20
        Me.a4.Text = 20
        Me.a5.Text = 20
        Me.a6.Text = 20
        Me.a7.Text = 20
        Me.A8.Text = 20
    End Sub

    'Add support for drag and drop
    Sub LabelMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            sender.DoDragDrop(sender.Text, DragDropEffects.Move)
        End If
    End Sub

    Private Sub box_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub box_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        sender.Text = e.Data.GetData(DataFormats.Text).ToString
        'Remove one of the equivalent values we just moved in from the available values
        For Each ctrl As Control In Me.AttrGroup.Controls
            If TypeOf ctrl Is Label Then
                If ctrl.Text = sender.Text Then 'If this is the value we just grabbed
                    ctrl.Text = ""
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub CustomArray_CheckedChanged(sender As Object, e As EventArgs) Handles CustomArray.CheckedChanged
        Me.a1.Text = ""
        Me.a2.Text = ""
        Me.a3.Text = ""
        Me.a4.Text = ""
        Me.a5.Text = ""
        Me.a6.Text = ""
        Me.a7.Text = ""
        Me.A8.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RemoveSkill.Show()
    End Sub
End Class
