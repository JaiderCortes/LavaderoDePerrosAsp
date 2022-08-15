Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class perro
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Private Sub perro_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            cone = New SqlConnection
            cone.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lava_perro.mdf;Integrated Security=True"
            Dim sql As String = "select * from perro"
            Dim sen As New SqlDataAdapter(sql, cone)
            ds = New DataSet
            sen.Fill(ds, "perro")

            idPerr.Text = ds.Tables("perro").Rows(0).Item("Id")
            nomPerr.Text = ds.Tables("perro").Rows(0).Item("Nombre")
            descPerr.Text = ds.Tables("perro").Rows(0).Item("Descripcion")
            nacPerr.Text = ds.Tables("perro").Rows(0).Item("Ano_nacimiento")

            Call cargarcombo("select * from cliente", ddIdCli, "Id", "Nombre")
            ddIdCli.SelectedValue = ds.Tables("perro").Rows(0).Item("Id_cliente")
        Catch ex As Exception
            MsgBox("Error de conexión: " + ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    'Primera línea de botones
    Protected Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        contperro = 0
        idPerr.Text = ds.Tables("perro").Rows(contperro).Item("Id")
        nomPerr.Text = ds.Tables("perro").Rows(contperro).Item("Nombre")
        descPerr.Text = ds.Tables("perro").Rows(contperro).Item("Descripcion")
        nacPerr.Text = ds.Tables("perro").Rows(contperro).Item("Ano_nacimiento")
        ddIdCli.SelectedValue = ds.Tables("perro").Rows(contperro).Item("Id_cliente")
    End Sub
    Protected Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        contperro = ds.Tables("perro").Rows.Count
        contperro = contperro - 1
        idPerr.Text = ds.Tables("perro").Rows(contperro).Item("Id")
        nomPerr.Text = ds.Tables("perro").Rows(contperro).Item("Nombre")
        descPerr.Text = ds.Tables("perro").Rows(contperro).Item("Descripcion")
        nacPerr.Text = ds.Tables("perro").Rows(contperro).Item("Ano_nacimiento")
        ddIdCli.SelectedValue = ds.Tables("perro").Rows(contperro).Item("Id_cliente")
    End Sub
    Protected Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        contperro = contperro - 1
        If contperro < 0 Then
            contperro = contperro + 1
            idPerr.Text = ds.Tables("perro").Rows(contperro).Item("Id")
            nomPerr.Text = ds.Tables("perro").Rows(contperro).Item("Nombre")
            descPerr.Text = ds.Tables("perro").Rows(contperro).Item("Descripcion")
            nacPerr.Text = ds.Tables("perro").Rows(contperro).Item("Ano_nacimiento")
            ddIdCli.SelectedValue = ds.Tables("perro").Rows(contperro).Item("Id_cliente")
        Else
            idPerr.Text = ds.Tables("perro").Rows(contperro).Item("Id")
            nomPerr.Text = ds.Tables("perro").Rows(contperro).Item("Nombre")
            descPerr.Text = ds.Tables("perro").Rows(contperro).Item("Descripcion")
            nacPerr.Text = ds.Tables("perro").Rows(contperro).Item("Ano_nacimiento")
            ddIdCli.SelectedValue = ds.Tables("perro").Rows(contperro).Item("Id_cliente")
        End If
    End Sub
    Protected Sub btnNex_Click(sender As Object, e As EventArgs) Handles btnNex.Click
        contperro = contperro + 1
        If contperro >= ds.Tables("perro").Rows.Count Then
            contperro = ds.Tables("perro").Rows.Count
            contperro = contperro - 1
        End If
        idPerr.Text = ds.Tables("perro").Rows(contperro).Item("Id")
        nomPerr.Text = ds.Tables("perro").Rows(contperro).Item("Nombre")
        descPerr.Text = ds.Tables("perro").Rows(contperro).Item("Descripcion")
        nacPerr.Text = ds.Tables("perro").Rows(contperro).Item("Ano_nacimiento")
        ddIdCli.SelectedValue = ds.Tables("perro").Rows(contperro).Item("Id_cliente")
    End Sub

    'Segunda línea de botones
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        idPerr.Text = ""
        nomPerr.Text = ""
        descPerr.Text = ""
        nacPerr.Text = ""

        btnNew.Enabled = False
        btnIns.Enabled = True
        btnUpd.Enabled = False
        btnDel.Enabled = False

        nomPerr.Focus()
    End Sub
    Protected Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        Call execute("insert into perro (Nombre, Descripcion, Ano_nacimiento, Id_cliente) values ('" & nomPerr.Text & "', '" & descPerr.Text & "', '" & nacPerr.Text & "', " & ddIdCli.SelectedValue & ")")
        btnNew.Enabled = True
        btnIns.Enabled = False
        btnUpd.Enabled = True
        btnDel.Enabled = True

        contperro = 0
        Response.Redirect("perro.aspx")
    End Sub
    Protected Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        Call execute("update perro set Nombre = '" & nomPerr.Text & "', Descripcion = '" & descPerr.Text & "', Ano_nacimiento = '" & nacPerr.Text & "', Id_cliente = " & ddIdCli.SelectedValue & " where Id = " & idPerr.Text & "")
        contperro = 0
        Response.Redirect("perro.aspx")
    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If MsgBox("¿Está seguro que desea eliminar a este perro?", MsgBoxStyle.YesNo, "¡Atencion!") = MsgBoxResult.Yes Then
            Call execute("delete from perro where Id = " & idPerr.Text & "")
            contperro = 0
            Response.Redirect("perro.aspx")
        Else
            Exit Sub
        End If
    End Sub

    'Carga del validador
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
    End Sub


End Class