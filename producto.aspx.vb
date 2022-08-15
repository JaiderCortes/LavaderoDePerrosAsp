Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class producto
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Private Sub producto_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            cone = New SqlConnection
            cone.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lava_perro.mdf;Integrated Security=True"
            Dim sql As String = "select * from producto"
            Dim sen As New SqlDataAdapter(sql, cone)
            ds = New DataSet
            sen.Fill(ds, "producto")

            idProd.Text = ds.Tables("producto").Rows(0).Item("Id")
            nomProd.Text = ds.Tables("producto").Rows(0).Item("Nombre")
        Catch ex As Exception
            MsgBox("Error de conexión: " + ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    'Primera línea de botones
    Protected Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        contprod = 0
        idProd.Text = ds.Tables("producto").Rows(contprod).Item("Id")
        nomProd.Text = ds.Tables("producto").Rows(contprod).Item("Nombre")
    End Sub
    Protected Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        contprod = ds.Tables("producto").Rows.Count
        contprod = contprod - 1
        idProd.Text = ds.Tables("producto").Rows(contprod).Item("Id")
        nomProd.Text = ds.Tables("producto").Rows(contprod).Item("Nombre")
    End Sub
    Protected Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        contprod = contprod - 1
        If contprod < 0 Then
            contprod = contprod + 1
            idProd.Text = ds.Tables("producto").Rows(contprod).Item("Id")
            nomProd.Text = ds.Tables("producto").Rows(contprod).Item("Nombre")
        Else
            idProd.Text = ds.Tables("producto").Rows(contprod).Item("Id")
            nomProd.Text = ds.Tables("producto").Rows(contprod).Item("Nombre")
        End If
    End Sub
    Protected Sub btnNex_Click(sender As Object, e As EventArgs) Handles btnNex.Click
        contprod = contprod + 1
        If contprod >= ds.Tables("producto").Rows.Count Then
            contprod = ds.Tables("producto").Rows.Count
            contprod = contprod - 1
        End If
        idProd.Text = ds.Tables("producto").Rows(contprod).Item("Id")
        nomProd.Text = ds.Tables("producto").Rows(contprod).Item("Nombre")
    End Sub

    'Segunda línea de botones
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        idProd.Text = ""
        nomProd.Text = ""

        btnNew.Enabled = False
        btnIns.Enabled = True
        btnUpd.Enabled = False
        btnDel.Enabled = False

        nomProd.Focus()
    End Sub
    Protected Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        Call execute("insert into producto (Nombre) values ('" & nomProd.Text & "')")
        btnNew.Enabled = True
        btnIns.Enabled = False
        btnUpd.Enabled = True
        btnDel.Enabled = True

        contprod = 0
        Response.Redirect("producto.aspx")
    End Sub
    Protected Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        Call execute("update producto set Nombre = '" & nomProd.Text & "' where Id = " & idProd.Text & "")
        contprod = 0
        Response.Redirect("producto.aspx")
    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If MsgBox("¿Está seguro que desea eliminar este producto?", MsgBoxStyle.YesNo, "¡Atencion!") = MsgBoxResult.Yes Then
            Call execute("delete from producto where Id = " & idProd.Text & "")
            contprod = 0
            Response.Redirect("producto.aspx")
        Else
            Exit Sub
        End If
    End Sub

    'Carga del validador
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
    End Sub
End Class