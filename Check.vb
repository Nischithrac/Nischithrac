﻿Imports System.Data.SqlClient
Public Class Check

    Public Property Stringpass As String
    Private Sub Check_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = Stringpass
        TextBox2.Visible = False
        Button3.Enabled = False

        DataGridView1.Visible = False
        Button2.Enabled = False
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query = "select * from [Table1] "
        Dim cmd = New SqlCommand(query, Con)
        Dim da = New SqlDataAdapter(cmd)
        Dim ds = New DataSet()
        da.Fill(ds)
        Dim Table2 As New DataTable
        Table2.Clear()
        da.Fill(Table2)
        DataGridView1.DataSource = Table2
        DataGridView1.MultiSelect = True


       


        Con.Close()
    End Sub

    
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Glossary.Show()
        Me.Hide()
    End Sub

   

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()

        If (TextBox3.Text = "" And TextBox3.TextLength < 10) Then
            MessageBox.Show("enter the Phone Number")
        Else


            Dim query = "select * from Table1 where [PhoneNumber] = '" & TextBox3.Text & "' and [Date] = '" & DateTimePicker1.Text & "'"
            Dim cmd = New SqlCommand(query, Con)
            Dim da = New SqlDataAdapter(cmd)
            Dim ds = New DataSet()
            Dim Table2 As New DataTable
            da.Fill(Table2)

            Dim row() As DataRow = Table2.Select("PhoneNumber = '" & TextBox3.Text & "' ")

            If row.Count = 0 Then
                MessageBox.Show(" Invalid Number ")
                Button2.Enabled = False
                Button3.Enabled = False
                DataGridView1.Visible = False

            Else


                da.SelectCommand = cmd

                Table2.Clear()
                da.Fill(Table2)
                DataGridView1.DataSource = Table2
                DataGridView1.Visible = True
                Button2.Enabled = True
                Button3.Enabled = True
                Con.Close()

            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project1\Project1\Project11.vb.mdf;Integrated Security=True;Connect Timeout=30")
        Con.Open()
        Dim query1 = "Delete from [Table1] where Product ='" & TextBox1.Text & "'"
        Dim cmd1 As SqlCommand
        cmd1 = New SqlCommand(query1, Con)
        cmd1.ExecuteNonQuery()
        Con.Close()
        MessageBox.Show("Item as deleted")
        Refresh()
        Button2.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.Text = "" And ComboBox2.Text = "" Then
            MessageBox.Show("Select the REquired Fields")
        End If
        If (ComboBox1.Text.Equals("Card")) Then
            Dim a As New card
            a.StringPass = TextBox2.Text
            a.Show()
            Me.Close()





        ElseIf (ComboBox1.Text.Equals("Cash")) Then
            ComboBox2.Visible = True
            If ComboBox2.Text = "Grocery" Then
                Dim a As New Print
                a.StringPass = TextBox2.Text
                a.Show()
                Me.Close()
           
            End If

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Visible = False
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If ((Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8)) Then
            MessageBox.Show("Enter OnlyNumbers")
        End If
    End Sub


    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class