Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class prod_lav
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Private Sub prod_lav_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            cone = New SqlConnection
            cone.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lava_perro.mdf;Integrated Security=True"
            Dim sql As String = "select * from productos_lavado"
            Dim sen As New SqlDataAdapter(sql, cone)
            ds = New DataSet
            sen.Fill(ds, "productos_lavado")

            idProdlav.Text = ds.Tables("productos_lavado").Rows(0).Item("Id")
            precProdlav.Text = ds.Tables("productos_lavado").Rows(0).Item("Precio")

            Call cargarcombo("select * from lavado", ddIdlav, "Id", "Codigo_batea")
            ddIdlav.SelectedValue = ds.Tables("productos_lavado").Rows(0).Item("Id_lavado")
            Call cargarcombo("select * from producto", ddIdprod, "Id", "Nombre")
            ddIdprod.SelectedValue = ds.Tables("productos_lavado").Rows(0).Item("Id_producto")
        Catch ex As Exception
            MsgBox("Error de conexión: " + ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    'Primera línea de botones
    Protected Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        contprodlav = 0
        idProdlav.Text = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id")
        precProdlav.Text = ds.Tables("productos_lavado").Rows(contprodlav).Item("Precio")
        ddIdlav.SelectedValue = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id_lavado")
        ddIdprod.SelectedValue = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id_producto")
    End Sub
    Protected Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        contprodlav = ds.Tables("productos_lavado").Rows.Count
        contprodlav = contprodlav - 1
        idProdlav.Text = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id")
        precProdlav.Text = ds.Tables("productos_lavado").Rows(contprodlav).Item("Precio")
        ddIdlav.SelectedValue = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id_lavado")
        ddIdprod.SelectedValue = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id_producto")
    End Sub
    Protected Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        contprodlav = contprodlav - 1
        If contprodlav < 0 Then
            contprodlav = contprodlav + 1
            idProdlav.Text = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id")
            precProdlav.Text = ds.Tables("productos_lavado").Rows(contprodlav).Item("Precio")
            ddIdlav.SelectedValue = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id_lavado")
            ddIdprod.SelectedValue = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id_producto")
        Else
            idProdlav.Text = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id")
            precProdlav.Text = ds.Tables("productos_lavado").Rows(contprodlav).Item("Precio")
            ddIdlav.SelectedValue = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id_lavado")
            ddIdprod.SelectedValue = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id_producto")
        End If
    End Sub
    Protected Sub btnNex_Click(sender As Object, e As EventArgs) Handles btnNex.Click
        contprodlav = contprodlav + 1
        If contprodlav >= ds.Tables("productos_lavado").Rows.Count Then
            contprodlav = ds.Tables("productos_lavado").Rows.Count
            contprodlav = contprodlav - 1
        End If
        idProdlav.Text = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id")
        precProdlav.Text = ds.Tables("productos_lavado").Rows(contprodlav).Item("Precio")
        ddIdlav.SelectedValue = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id_lavado")
        ddIdprod.SelectedValue = ds.Tables("productos_lavado").Rows(contprodlav).Item("Id_producto")
    End Sub

    'Segunda línea de botones
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        idProdlav.Text = ""
        precProdlav.Text = ""

        btnNew.Enabled = False
        btnIns.Enabled = True
        btnUpd.Enabled = False
        btnDel.Enabled = False

        precProdlav.Focus()
    End Sub
    Protected Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        Call execute("insert into productos_lavado (Precio, Id_lavado, Id_producto) values ('" & precProdlav.Text & "', " & ddIdlav.SelectedValue & ", " & ddIdprod.SelectedValue & ")")
        btnNew.Enabled = True
        btnIns.Enabled = False
        btnUpd.Enabled = True
        btnDel.Enabled = True

        contprodlav = 0
        Response.Redirect("prod_lav.aspx")
    End Sub
    Protected Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        Call execute("update productos_lavado set Precio = '" & precProdlav.Text & "', Id_lavado = " & ddIdlav.SelectedValue & ", Id_producto = " & ddIdprod.SelectedValue & " where Id = " & idProdlav.Text & "")
        contprodlav = 0
        Response.Redirect("prod_lav.aspx")
    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If MsgBox("¿Está seguro que desea eliminar este producto_lavado?", MsgBoxStyle.YesNo, "¡Atencion!") = MsgBoxResult.Yes Then
            Call execute("delete from productos_lavado where Id = " & idProdlav.Text & "")
            contperro = 0
            Response.Redirect("prod_lav.aspx")
        Else
            Exit Sub
        End If
    End Sub

    'Carga del validador
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
    End Sub


End Class