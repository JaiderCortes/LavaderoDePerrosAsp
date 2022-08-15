Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class lavado
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Private Sub lavado_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            cone = New SqlConnection
            cone.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lava_perro.mdf;Integrated Security=True"
            Dim sql As String = "select * from lavado"
            Dim sen As New SqlDataAdapter(sql, cone)
            ds = New DataSet
            sen.Fill(ds, "lavado")

            idLav.Text = ds.Tables("lavado").Rows(0).Item("Id")
            codbLav.Text = ds.Tables("lavado").Rows(0).Item("Codigo_batea")

            Call cargarcombo("select * from perro", ddIdPerr, "Id", "Nombre")
            ddIdPerr.SelectedValue = ds.Tables("lavado").Rows(0).Item("Id_perro")
        Catch ex As Exception
            MsgBox("Error de conexión: " + ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    'Primera lína de botones
    Protected Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        contlav = 0
        idLav.Text = ds.Tables("lavado").Rows(contlav).Item("Id")
        codbLav.Text = ds.Tables("lavado").Rows(contlav).Item("Codigo_batea")
        ddIdPerr.SelectedValue = ds.Tables("lavado").Rows(contlav).Item("Id_perro")
    End Sub
    Protected Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        contlav = ds.Tables("lavado").Rows.Count
        contlav = contlav - 1
        idLav.Text = ds.Tables("lavado").Rows(contlav).Item("Id")
        codbLav.Text = ds.Tables("lavado").Rows(contlav).Item("Codigo_batea")
        ddIdPerr.SelectedValue = ds.Tables("lavado").Rows(contlav).Item("Id_perro")
    End Sub
    Protected Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        contlav = contlav - 1
        If contlav < 0 Then
            contlav = contlav + 1
            idLav.Text = ds.Tables("lavado").Rows(contlav).Item("Id")
            codbLav.Text = ds.Tables("lavado").Rows(contlav).Item("Codigo_batea")
            ddIdPerr.SelectedValue = ds.Tables("lavado").Rows(contlav).Item("Id_perro")
        Else
            idLav.Text = ds.Tables("lavado").Rows(contlav).Item("Id")
            codbLav.Text = ds.Tables("lavado").Rows(contlav).Item("Codigo_batea")
            ddIdPerr.SelectedValue = ds.Tables("lavado").Rows(contlav).Item("Id_perro")
        End If
    End Sub
    Protected Sub btnNex_Click(sender As Object, e As EventArgs) Handles btnNex.Click
        contlav = contlav + 1
        If contlav >= ds.Tables("lavado").Rows.Count Then
            contlav = ds.Tables("lavado").Rows.Count
            contlav = contlav - 1
        End If
        idLav.Text = ds.Tables("lavado").Rows(contlav).Item("Id")
        codbLav.Text = ds.Tables("lavado").Rows(contlav).Item("Codigo_batea")
        ddIdPerr.SelectedValue = ds.Tables("lavado").Rows(contlav).Item("Id_perro")
    End Sub

    'Segunda línea de botones
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        idLav.Text = ""
        codbLav.Text = ""

        btnNew.Enabled = False
        btnIns.Enabled = True
        btnUpd.Enabled = False
        btnDel.Enabled = False

        codbLav.Focus()
    End Sub
    Protected Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        Call execute("insert into lavado (Codigo_batea, Id_perro) values (" & codbLav.Text & ", " & ddIdPerr.SelectedValue & ")")
        btnNew.Enabled = True
        btnIns.Enabled = False
        btnUpd.Enabled = True
        btnDel.Enabled = True

        contlav = 0
        Response.Redirect("lavado.aspx")
    End Sub
    Protected Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        Call execute("update lavado set Codigo_batea = " & codbLav.Text & ", Id_perro = " & ddIdPerr.SelectedValue & " where Id = " & idLav.Text & "")
        contlav = 0
        Response.Redirect("lavado.aspx")
    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If MsgBox("¿Está seguro que desea eliminar este lavado?", MsgBoxStyle.YesNo, "¡Atencion!") Then
            Call execute("delete from lavado where Id = " & idLav.Text & "")
            contlav = 0
            Response.Redirect("lavado.aspx")
        Else
            Exit Sub
        End If
    End Sub

    'Carga de validador
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
    End Sub
End Class