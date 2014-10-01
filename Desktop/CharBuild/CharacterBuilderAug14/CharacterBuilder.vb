Imports System.Data.OleDb
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class CB
    Public Const NUM_ATTRIBUTES = 8
    Public oldAttr As String 'Used to track the previous attribute
    Public firstTime = True 'Is this the first Attribute we picked?
    Public oldTextBox As String 'Also used for previous attribute
    Public talMan As New TalentManager 'The one instance of talent manager
    Private PC As New PlayerCharacter

    Private Sub CharacterBuilder_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        'Add this handler to every checkbox in the skills section.
        'Used to count remaining skills
        For Each ctrl As Control In Me.GroupBox4.Controls
            If TypeOf ctrl Is CheckBox Then
                AddHandler (DirectCast(ctrl, CheckBox).CheckedChanged), AddressOf Check_Clicked
            End If
            ctrl = Me.GetNextControl(ctrl, True)
        Next

        'Add this handler to every label in the attributes section
        For Each ctrl As Control In Me.AttrGroup.Controls
            If TypeOf ctrl Is Label Then
                AddHandler ctrl.MouseDown, AddressOf LabelMouseDown     'Used for drag and drop
            ElseIf TypeOf ctrl Is TextBox Then
                AddHandler ctrl.DragEnter, AddressOf box_DragEnter      'Used for drag and drop
                AddHandler ctrl.DragDrop, AddressOf box_DragDrop        'Used for drag and drop
                AddHandler ctrl.TextChanged, AddressOf box_TextChanged  'Check homebrew, clear the appropriate value
                AddHandler ctrl.KeyPress, AddressOf box_KeyPress        'Restrict to only digits. Used for custom arrays
            End If
            ctrl = Me.GetNextControl(ctrl, True)
        Next
    End Sub

    'Manages the count of skills remaining.
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

    'Used to check if the system is homebrewed. Will be updated as needed.
    Private Sub check_homebrew()
        'If we chose too many skills
        If CInt(Me.count.Text) < 0 Or
            Not legal_attr_avg() Or
            custom_skills() Then
            homebrewed.Checked = True
        Else
            homebrewed.Checked = False
        End If
    End Sub

    'returns true if one or more custom skills have been selected, false otherwise.
    Private Function custom_skills() As Boolean
        If Me.blank1.Checked = True Or
            Me.Blank2.Checked = True Or
            Me.blank3.Checked = True Or
            Me.blank4.Checked = True Or
            Me.blank5.Checked = True Then
            Return True
        Else
            Return False
        End If
    End Function

    'Returns true if the attributes have been completed legally or have not been completed
    'Returns false if the attributes have been completed illegally.
    Private Function legal_attr_avg() As Boolean
        If completed_attr() Then
            Dim total As Integer
            total = 0
            For Each ctrl As Control In Me.AttrGroup.Controls
                If TypeOf ctrl Is TextBox Then
                    'If this is a number, add it.
                    If IsNumeric(ctrl.Text) Then
                        total = total + CInt(ctrl.Text)
                    End If
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

    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Tabcontrol1.DrawItem
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
        toggle_Readonly(True)
        clear_attr()
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
        toggle_Readonly(True)
        clear_attr()
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
        toggle_Readonly(True)
        clear_attr()
    End Sub

    'Add support for drag and drop
    Sub LabelMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            oldTextBox = sender.text
            sender.DoDragDrop(sender.Text, DragDropEffects.Move)
        End If
    End Sub

    Private Sub box_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        e.Effect = DragDropEffects.Move
    End Sub

    'When we drag and drop.
    Private Sub box_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        oldAttr = sender.text 'Set the previous attribute value
        sender.Text = e.Data.GetData(DataFormats.Text).ToString

        'Remove one of the equivalent values we just moved in from the available values
        For Each ctrl As Control In Me.AttrGroup.Controls
            If TypeOf ctrl Is Label Then
                'If the label is equal to the number we dragged in
                If oldAttr = "" Then
                    If ctrl.Text = sender.text Then
                        ctrl.Text = ""
                        Exit For
                    End If
                ElseIf ctrl.Text = oldTextBox Then
                    ctrl.Text = oldAttr ' Set it equal to the old data
                    Exit For
                End If
            End If
        Next
        oldAttr = e.Data.GetData(DataFormats.Text).ToString
    End Sub

    'Sets the read only flag of all the textboxes for the attributes 
    'to the value of enable
    Private Sub toggle_Readonly(enable As Boolean)
        For Each ctl As Control In AttrGroup.Controls
            If TypeOf ctl Is TextBox Then
                DirectCast(ctl, TextBox).ReadOnly = enable 'We can write to this
            End If
        Next
    End Sub

    'Clears the values of all the attribute fields
    Private Sub clear_attr()
        For Each ctl As Control In AttrGroup.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
            End If
        Next
    End Sub

    'If they select the custom array radio button
    Private Sub CustomArray_CheckedChanged(sender As Object, e As EventArgs) Handles CustomArray.CheckedChanged
        Me.a1.Text = ""
        Me.a2.Text = ""
        Me.a3.Text = ""
        Me.a4.Text = ""
        Me.a5.Text = ""
        Me.a6.Text = ""
        Me.a7.Text = ""
        Me.A8.Text = ""
        toggle_Readonly(False)
        clear_attr()
    End Sub

    'If they choose to remove a custom skill
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not Me.blank1.Text = "" Or
            Not Me.Blank2.Text = "" Or
            Not Me.blank3.Text = "" Or
            Not Me.blank4.Text = "" Or
            Not Me.blank5.Text = "" Then
            RemoveSkill.Show()
        End If
    End Sub

    'When an attribute box changes
    Private Sub box_TextChanged(sender As Object, e As EventArgs)
        check_homebrew()
    End Sub

    'Restrict attribute boxes to digits.
    Private Sub box_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True 'We took care of it, move along.
        End If

    End Sub

    Private Sub strbox_TextChanged(sender As Object, e As EventArgs) Handles strbox.TextChanged

    End Sub

    'Talent fill debug
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim address As String = My.Computer.FileSystem.CurrentDirectory + "\database1.accdb"
        Dim conString As String = "Provider=Microsoft.ACE.OLEDB.12.0;data source=" + address + ";"
        Dim conn As New OleDbConnection(conString)
        Dim dbAdapter As OleDbDataAdapter
        Dim ds As New DataSet
        Dim i, j As Integer
        Dim sql As String = "SELECT * FROM Talents"
        'Dim cmd As New OleDbCommand(sql, conn)
        Try
            conn.Open()
            dbAdapter = New OleDbDataAdapter(sql, conn)
            dbAdapter.Fill(ds)
            Dim item As New ListViewItem
            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 1 To 6
                    If Not ds.Tables(0).Rows(i).Item(j).ToString = "" Then
                        item.SubItems.Add(j - 1)
                        item.SubItems(j - 1).Text = ds.Tables(0).Rows(i).Item(j)
                    Else
                        item.SubItems.Add(j - 1)
                        item.SubItems(j - 1).Text = ""
                        ' TalentName.Items.Add("")
                    End If
                Next
                TalentName.Items.Add(item)
                item = New ListViewItem
            Next
            dbAdapter.Dispose()
            conn.Close()
        Catch ex As Exception
            MsgBox("Cannot open connection!" & ex.ToString)
        End Try
        TalentName.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        TalentName.ListViewItemSorter = New ListViewItemComparer
        TalentName.Sort()


    End Sub

    '''''''''''''''''''''''''Begin next/previous buttons
    'Next
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Tabcontrol1.SelectedIndex = 1
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Tabcontrol1.SelectedIndex = 2
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Tabcontrol1.SelectedIndex = 3
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Tabcontrol1.SelectedIndex = 4
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs)
        Me.Tabcontrol1.SelectedIndex = 5
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Me.Tabcontrol1.SelectedIndex = 5
    End Sub
    'Previous
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Tabcontrol1.SelectedIndex = 0
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Tabcontrol1.SelectedIndex = 1
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Me.Tabcontrol1.SelectedIndex = 2
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Me.Tabcontrol1.SelectedIndex = 3
    End Sub
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Me.Tabcontrol1.SelectedIndex = 4
    End Sub
    ''''''''''''''''''''''''''''''End next/previous buttons

    'Talent debug
    Private Sub Button12_Click_1(sender As Object, e As EventArgs) Handles Button12.Click
        talMan.initializeManager()
        Dim myTal As talent = talMan.allTalents(0)
        myTal.implement()
    End Sub

    'Print to screen debug
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim addressStart As String = My.Computer.FileSystem.CurrentDirectory + "\chimerasheet.pdf" 'Here's our template, in the same directory
        Dim addressEnd As String = My.Computer.FileSystem.CurrentDirectory + "\test.pdf" 'Find a way to name the new file dynamically
        Dim readerpdf As New PdfReader(addressStart)
        Dim stamperpdf As New PdfStamper(readerpdf, New FileStream(addressEnd, FileMode.Create))
        Dim pdfFormFields As AcroFields = stamperpdf.AcroFields

        For Each pfid In readerpdf.AcroFields.Fields
            If pfid.Key.ToString = "Race" Then
                pdfFormFields.SetField(pfid.Key.ToString, PC.getRace)
            Else
                pdfFormFields.SetField(pfid.Key.ToString, pfid.Key.ToString)
            End If
        Next


        'Remove the option to edit afterwards
        stamperpdf.FormFlattening = False
        stamperpdf.Close()

    End Sub

    'Race changed
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        PC.setRace(sender.text)
    End Sub

    'Debug menu fill for talnets
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        TalentName.Items.Clear()
        talMan.initializeManager()
        Dim item As New ListViewItem
        'Manually populate the entire thing, with all the fields  
        Dim i As Integer = 0
        For Each tal As talent In talMan.allTalents
            'The first thing we need to do is create subsections in the new item
            For j = 0 To 5 'Number of rows in listview
                item.SubItems.Add(j) 'Create six lines
            Next
            If i = 2 Then 'Debug statement because we only have 2 implemented
                Exit For
            End If
            'TODO eventuall add only show legal, include support for multiply taken talents
            'Begin manual fill
            item.SubItems(0).Text = tal.name
            item.SubItems(1).Text = tal.talPre
            item.SubItems(2).Text = tal.spellPre
            item.SubItems(3).Text = tal.skillPre
            item.SubItems(4).Text = tal.attrPre
            item.SubItems(5).Text = tal.description

            TalentName.Items.Add(item)
            item = New ListViewItem
            i += 1
        Next
        TalentName.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        TalentName.ListViewItemSorter = New ListViewItemComparer
        TalentName.Sort()
    End Sub

    'On Name change
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        PC.setName(sender.text)
    End Sub

    'On height change (not restricted to numbers)
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        PC.height = sender.text
    End Sub

    'On weight change (Not restricted to numbers)
    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        PC.weight = sender.text
    End Sub

    'We picked a talent and want to take it
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim temporary As ListViewItem = TalentName.SelectedItems(0)
        TalentDescription.Text = temporary.GetSubItemAt(0, 0).ToString


    End Sub

    Private Sub CheckBox20_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox20.CheckedChanged

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub
End Class

''''''''''''''''''''''OTHER CLASSES START HERE


'Used to actually store all of the information. This is what we're building
Class PlayerCharacter
    Public Property level As Integer
    Public Property name As String
    Public Property race As String
    Public Property AC As Integer
    Private Property fort As Integer
    Public Property ref As Integer
    Public Property will As Integer
    Public Property weight As String
    Public Property height As String
    Dim TalentList() As talent 'Might need custom getter/setter for this. That's fine.
    Dim SpellList() As spell

    'Constructor doesn't set much
    Public Sub New()
        level = 1
    End Sub

    '''''''''''''Getters and setters
    Function getName() As String
        Return name
    End Function
    Sub setName(newName As String)
        name = newName
    End Sub
    Function getLevel() As Integer
        Return level
    End Function
    Sub setRace(newRace As String)
        race = newRace
    End Sub
    Function getRace() As String
        Return race
    End Function
    Sub setAC(newAC As Integer)
        AC = newAC
    End Sub
    Function getAC() As Integer
        Return AC
    End Function
    Sub setRef(newRef As Integer)
        ref = newRef
    End Sub
    Function getRef() As Integer
        Return ref
    End Function
    Sub incRef()
        ref += 1
    End Sub
    Sub decRef()
        ref -= 1
    End Sub
    Function getFort() As Integer
        Return fort
    End Function
    Sub setFort(newFort As Integer)
        fort = newFort
    End Sub
    Function getWill() As Integer
        Return will
    End Function
    Sub setWill(newWill As Integer)
        will = newWill
    End Sub



    Sub levelUp()
        level += 1
    End Sub

    Sub delevel()
        If level > 1 Then
            level -= 1
        End If
    End Sub



    Public Sub addTal(newTalent As talent)
        ReDim Preserve TalentList(0 To UBound(TalentList) + 1)
        TalentList(UBound(TalentList)) = newTalent
    End Sub

    Public Sub addSpell(newSpell As spell)
        ReDim Preserve SpellList(0 To UBound(SpellList) + 1) 'increase the size of the array by one
        SpellList(UBound(SpellList)) = newSpell
    End Sub
End Class 'Player Character


' Implements the manual sorting of items by column.
Class ListViewItemComparer
    Implements IComparer
    Private col As Integer

    Public Sub New()
        col = 0
    End Sub

    Public Sub New(column As Integer)
        col = column
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer _
                            Implements System.Collections.IComparer.Compare
        Dim returnVal As Integer = -1
        returnVal = [String].Compare(CType(x,  _
                        ListViewItem).SubItems(col).Text, _
                        CType(y, ListViewItem).SubItems(col).Text)
        Return returnVal
    End Function
End Class 'ListComparer


'Used to define and manage all of the talents
Public Class TalentManager
    Sub New()

    End Sub
    Public Const NUM_TALENTS = 126
    Dim talIndex As Integer = 0

    Public allTalents(0 To NUM_TALENTS) As talent ' An array of all the talents. Add to this as we go
    Public implTalents(0 To NUM_TALENTS) As Action 'Array of actions (basically subroutines) that handle all of the implementations.
    Public unimplTalents(0 To NUM_TALENTS) As Action 'Array of actions that handle unimplementation

    Sub initializeManager()
        allTalents(talIndex) = New talent("Adaptive Skin", "", "", "", "", "Gain resist five to one damage type", True, talIndex)
        implTalents(talIndex) = AddressOf impl_AdaptiveSkin
        unimplTalents(talIndex) = AddressOf unimpl_AdapativeSkin
        talIndex += 1

        allTalents(talIndex) = New talent("Assassin's Threat", "", "", "", "", "Your damage multiplier inceases by 1 against creatures granting combat advantage to you.", False, talIndex)
        implTalents(talIndex) = AddressOf impl_AssassinsThreat
        unimplTalents(talIndex) = AddressOf unimpl_AssassinsThreat
        talIndex += 1

    End Sub

    Function findInTalents(searchText As String) As talent
        For Each tal As talent In allTalents
            If tal.getDescription = searchText Then
                Return tal
            End If
        Next
        MsgBox("An error occured")
        Return New talent("", "", "", "", "", "", "", False) ' Shouldn't be reached
    End Function

    Sub impl_AdaptiveSkin()
        Dim resistType As String = InputBox("Enter the type of resistance you'd like", "Adaptive Skin Resistance", )
        Dim defaultVal As String = "_____"
        If resistType = "" Then
            resistType = defaultVal 'If they didn't pick a type, they get a blank
        End If
        MsgBox(resistType)
    End Sub

    Sub unimpl_AdapativeSkin()
        MsgBox("This is also a test")
    End Sub

    Sub impl_AssassinsThreat()

    End Sub

    Sub unimpl_AssassinsThreat()

    End Sub

    'talIndex = talIndex + 1
End Class 'Talentmanager

'Talent class
Public Class talent
    Public Property name As String
    Public Property spellPre As String
    Public Property skillPre As String
    Public Property attrPre As String
    Public Property talPre As String
    Public Property description As String
    Public Property implemented As Boolean 'Used to maintain a checkbox. If true, we did all the math etc. for the player
    Public Property retakeable As Boolean 'Can we select this multiple times?
    Public Property numTalent As Integer ' The number in the array

    Public Sub New(newName As String, newSpellPre As String, newSkillPre As String, newAttrPre As String, newTalPre As String, newDesc As String, multiTake As Boolean, num As Integer)
        name = newName
        spellPre = newSpellPre
        skillPre = newSkillPre
        attrPre = newAttrPre
        talPre = newTalPre
        description = newDesc
        retakeable = multiTake
        numTalent = num
    End Sub
    Public Sub implement()
        Dim impl As action = CB.talMan.implTalents(numTalent)
        impl()
    End Sub
    Public Sub unimplement()
        Dim unimpl As action = CB.talMan.unimplTalents(numTalent)
        unimpl()
    End Sub
    Public Function getDescription() As String
        Return description
    End Function

End Class

'The spell class
MustInherit Class spell
    Private Property name As String
    Private Property skillPre As String
    Private Property attrPre As String
    Private Property SpellPre As String
    Private Property description As String

    Public Sub New(newName As String, newSkillPre As String, newAttrPre As String, newSpellPre As String, newDesc As String)
        name = newName
        skillPre = newSkillPre
        attrPre = newAttrPre
        SpellPre = newSpellPre
        description = newDesc
    End Sub
End Class