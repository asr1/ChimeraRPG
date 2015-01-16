'Imports System.Data.SqlClient
'Public Class Form1
'    Private Sub Form1_Load(sender As Object, e As EventArgs) _
'    Handles MyBase.Load
'        'TODO: This line of code loads data into the 'Database1DataSet.Talents' table. You can move, or remove it, as needed.
'        Me.TalentsTableAdapter.Fill(Me.Database1DataSet.Talents)
'        ' Set the caption bar text of the form.   
'        Me.Text = "Talents"
'    End Sub
'    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
'        Dim connection As SqlConnection = New sqlconnection()
'        connection.ConnectionString = "Data Source=KABIR-DESKTOP; _"
'          Initial Catalog=testDB;Integrated Security=True"
'        connection.Open()
'        Dim adp As SqlDataAdapter = New SqlDataAdapter _
'        ("select * from Customers", connection)
'        Dim ds As DataSet = New DataSet()
'        adp.Fill(ds)
'        talTab.DataSource = ds.Tables(0)
'    End Sub
'End Class