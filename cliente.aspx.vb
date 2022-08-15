Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class cliente
    Inherits System.Web.UI.Page
    Public ds As DataSet

    'Selección de datos de la tabla
    Private Sub cliente_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            cone = New SqlConnection
            cone.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lava_perro.mdf;Integrated Security=True"
            Dim sql As String = "select * from cliente"
            Dim sen As New SqlDataAdapter(sql, cone)
            ds = New DataSet
            sen.Fill(ds, "cliente")

            idCli.Text = ds.Tables("cliente").Rows(0).Item("Id")
            nomCli.Text = ds.Tables("cliente").Rows(0).Item("Nombre")
            apeCli.Text = ds.Tables("cliente").Rows(0).Item("Apellido")
            telCli.Text = ds.Tables("cliente").Rows(0).Item("Telefono")
            dircli.Text = ds.Tables("cliente").Rows(0).Item("Direccion")
        Catch ex As Exception
            MsgBox("Error de conexión: " + ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    'Primera línea de botones, botones de seleccion
    Protected Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        contcli = 0
        idCli.Text = ds.Tables("cliente").Rows(contcli).Item("Id")
        nomCli.Text = ds.Tables("cliente").Rows(contcli).Item("Nombre")
        apeCli.Text = ds.Tables("cliente").Rows(contcli).Item("Apellido")
        telCli.Text = ds.Tables("cliente").Rows(contcli).Item("Telefono")
        dircli.Text = ds.Tables("cliente").Rows(contcli).Item("Direccion")
    End Sub
    Protected Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        contcli = ds.Tables("cliente").Rows.Count
        contcli = contcli - 1
        idCli.Text = ds.Tables("cliente").Rows(contcli).Item("Id")
        nomCli.Text = ds.Tables("cliente").Rows(contcli).Item("Nombre")
        apeCli.Text = ds.Tables("cliente").Rows(contcli).Item("Apellido")
        telCli.Text = ds.Tables("cliente").Rows(contcli).Item("Telefono")
        dircli.Text = ds.Tables("cliente").Rows(contcli).Item("Direccion")
    End Sub
    Protected Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        contcli = contcli - 1
        If contcli < 0 Then
            contcli = contcli + 1
            idCli.Text = ds.Tables("cliente").Rows(contcli).Item("Id")
            nomCli.Text = ds.Tables("cliente").Rows(contcli).Item("Nombre")
            apeCli.Text = ds.Tables("cliente").Rows(contcli).Item("Apellido")
            telCli.Text = ds.Tables("cliente").Rows(contcli).Item("Telefono")
            dircli.Text = ds.Tables("cliente").Rows(contcli).Item("Direccion")
        Else
            idCli.Text = ds.Tables("cliente").Rows(contcli).Item("Id")
            nomCli.Text = ds.Tables("cliente").Rows(contcli).Item("Nombre")
            apeCli.Text = ds.Tables("cliente").Rows(contcli).Item("Apellido")
            telCli.Text = ds.Tables("cliente").Rows(contcli).Item("Telefono")
            dircli.Text = ds.Tables("cliente").Rows(contcli).Item("Direccion")
        End If
    End Sub
    Protected Sub btnNex_Click(sender As Object, e As EventArgs) Handles btnNex.Click
        contcli = contcli + 1
        If contcli >= ds.Tables("cliente").Rows.Count Then
            contcli = ds.Tables("cliente").Rows.Count
            contcli = contcli - 1
        End If
        idCli.Text = ds.Tables("cliente").Rows(contcli).Item("Id")
        nomCli.Text = ds.Tables("cliente").Rows(contcli).Item("Nombre")
        apeCli.Text = ds.Tables("cliente").Rows(contcli).Item("Apellido")
        telCli.Text = ds.Tables("cliente").Rows(contcli).Item("Telefono")
        dircli.Text = ds.Tables("cliente").Rows(contcli).Item("Direccion")
    End Sub

    'Segunda linea de botones insert, update, delete
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        idCli.Text = ""
        nomCli.Text = ""
        apeCli.Text = ""
        telCli.Text = ""
        dircli.Text = ""

        btnNew.Enabled = False
        btnIns.Enabled = True
        btnUpd.Enabled = False
        btnDel.Enabled = False
        btnCan.Visible = True

        nomCli.Focus()
    End Sub
    Protected Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        Call execute("insert into cliente (Nombre, Apellido, Telefono, Direccion) values ('" & nomCli.Text & "', '" & apeCli.Text & "'," & telCli.Text & ",'" & dircli.Text & "')")
        btnNew.Enabled = True
        btnIns.Enabled = False
        btnUpd.Enabled = True
        btnDel.Enabled = True

        contcli = 0
        Response.Redirect("cliente.aspx")
    End Sub
    Protected Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        Call execute("update cliente set Nombre = '" & nomCli.Text & "', Apellido = '" & apeCli.Text & "', Telefono = '" & telCli.Text & "', Direccion = '" & dircli.Text & "' where Id = " & idCli.Text & "")
        contcli = 0
        Response.Redirect("cliente.aspx")
    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If MsgBox("¿Está seguro que desea eliminar a este cliente?", MsgBoxStyle.YesNo, "¡Atencion!") = MsgBoxResult.Yes Then
            Call execute("delete from cliente where Id = " & idCli.Text & "")
            contcli = 0
            Response.Redirect("cliente.aspx")
        Else
            Exit Sub
        End If
    End Sub

    'Carga del validador
    Private Sub cliente_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
    End Sub
End Class