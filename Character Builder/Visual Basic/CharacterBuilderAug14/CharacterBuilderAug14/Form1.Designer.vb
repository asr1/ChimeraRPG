<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.talTab = New System.Windows.Forms.DataGridView()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TalentNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TalentPrereqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpellPrereqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AttrPrereqDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TalentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Database1DataSet = New CharacterBuilderAug14.Database1DataSet()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TalentsTableAdapter = New CharacterBuilderAug14.Database1DataSetTableAdapters.TalentsTableAdapter()
        CType(Me.talTab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TalentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Database1DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'talTab
        '
        Me.talTab.AutoGenerateColumns = False
        Me.talTab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.talTab.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.TalentNameDataGridViewTextBoxColumn, Me.TalentPrereqDataGridViewTextBoxColumn, Me.SpellPrereqDataGridViewTextBoxColumn, Me.AttrPrereqDataGridViewTextBoxColumn, Me.DescriptionDataGridViewTextBoxColumn})
        Me.talTab.DataSource = Me.TalentsBindingSource
        Me.talTab.Location = New System.Drawing.Point(3, 12)
        Me.talTab.Name = "talTab"
        Me.talTab.Size = New System.Drawing.Size(477, 151)
        Me.talTab.TabIndex = 0
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        '
        'TalentNameDataGridViewTextBoxColumn
        '
        Me.TalentNameDataGridViewTextBoxColumn.DataPropertyName = "Talent Name"
        Me.TalentNameDataGridViewTextBoxColumn.HeaderText = "Talent Name"
        Me.TalentNameDataGridViewTextBoxColumn.Name = "TalentNameDataGridViewTextBoxColumn"
        '
        'TalentPrereqDataGridViewTextBoxColumn
        '
        Me.TalentPrereqDataGridViewTextBoxColumn.DataPropertyName = "Talent Prereq"
        Me.TalentPrereqDataGridViewTextBoxColumn.HeaderText = "Talent Prereq"
        Me.TalentPrereqDataGridViewTextBoxColumn.Name = "TalentPrereqDataGridViewTextBoxColumn"
        '
        'SpellPrereqDataGridViewTextBoxColumn
        '
        Me.SpellPrereqDataGridViewTextBoxColumn.DataPropertyName = "Spell Prereq"
        Me.SpellPrereqDataGridViewTextBoxColumn.HeaderText = "Spell Prereq"
        Me.SpellPrereqDataGridViewTextBoxColumn.Name = "SpellPrereqDataGridViewTextBoxColumn"
        '
        'AttrPrereqDataGridViewTextBoxColumn
        '
        Me.AttrPrereqDataGridViewTextBoxColumn.DataPropertyName = "Attr Prereq"
        Me.AttrPrereqDataGridViewTextBoxColumn.HeaderText = "Attr Prereq"
        Me.AttrPrereqDataGridViewTextBoxColumn.Name = "AttrPrereqDataGridViewTextBoxColumn"
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        '
        'TalentsBindingSource
        '
        Me.TalentsBindingSource.DataMember = "Talents"
        Me.TalentsBindingSource.DataSource = Me.Database1DataSet
        '
        'Database1DataSet
        '
        Me.Database1DataSet.DataSetName = "Database1DataSet"
        Me.Database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(103, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Fill"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TalentsTableAdapter
        '
        Me.TalentsTableAdapter.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 304)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.talTab)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.talTab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TalentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Database1DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents talTab As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Database1DataSet As CharacterBuilderAug14.Database1DataSet
    Friend WithEvents TalentsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TalentsTableAdapter As CharacterBuilderAug14.Database1DataSetTableAdapters.TalentsTableAdapter
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TalentNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TalentPrereqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpellPrereqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AttrPrereqDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
