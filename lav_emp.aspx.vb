Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class lav_emp
    Inherits System.Web.UI.Page
    Dim ds As DataSet
    Private Sub lav_emp_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            cone = New SqlConnection
            cone.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lava_perro.mdf;Integrated Security=True"
            Dim sql As String = "select * from lavado_empleado"
            Dim sen As New SqlDataAdapter(sql, cone)
            ds = New DataSet
            sen.Fill(ds, "lavado_empleado")

            idLavemp.Text = ds.Tables("lavado_empleado").Rows(0).Item("Id")
            horLavemp.Text = ds.Tables("lavado_empleado").Rows(0).Item("Id")
            fechLavemp.Text = ds.Tables("lavado_empleado").Rows(0).Item("Fecha")

            Call cargarcombo("select * from lavado", ddIdlav, "Id", "Codigo_batea")
            ddIdlav.SelectedValue = ds.Tables("lavado_empleado").Rows(0).Item("Id_lavado")
            Call cargarcombo("select * from empleado", ddIdemp, "Id", "Nombre")
            ddIdemp.SelectedValue = ds.Tables("lavado_empleado").Rows(0).Item("Id_empleado")
        Catch ex As Exception
            MsgBox("Error de conexión: " + ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    'Primera línea de botones
    Protected Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        contlavemp = 0
        idLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id")
        horLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Hora")
        fechLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Fecha")
        ddIdlav.SelectedValue = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id_lavado")
        ddIdemp.SelectedValue = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id_empleado")
    End Sub
    Protected Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        contlavemp = ds.Tables("lavado_empleado").Rows.Count
        contlavemp = contlavemp - 1
        idLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id")
        horLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Hora")
        fechLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Fecha")
        ddIdlav.SelectedValue = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id_lavado")
        ddIdemp.SelectedValue = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id_empleado")
    End Sub
    Protected Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        contlavemp = contlavemp - 1
        If contlavemp < 0 Then
            contlavemp = contlavemp + 1
            idLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id")
            horLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Hora")
            fechLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Fecha")
            ddIdlav.SelectedValue = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id_lavado")
            ddIdemp.SelectedValue = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id_empleado")
        Else
            idLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id")
            horLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Hora")
            fechLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Fecha")
            ddIdlav.SelectedValue = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id_lavado")
            ddIdemp.SelectedValue = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id_empleado")
        End If
    End Sub
    Protected Sub btnNex_Click(sender As Object, e As EventArgs) Handles btnNex.Click
        contlavemp = contlavemp + 1
        If contlavemp >= ds.Tables("lavado_empleado").Rows.Count Then
            contlavemp = ds.Tables("lavado_empleado").Rows.Count
            contlavemp = contlavemp - 1
        End If
        idLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id")
        horLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Hora")
        fechLavemp.Text = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Fecha")
        ddIdlav.SelectedValue = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id_lavado")
        ddIdemp.SelectedValue = ds.Tables("lavado_empleado").Rows(contlavemp).Item("Id_empleado")
    End Sub

    'Segunda línea de botones
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        idLavemp.Text = ""
        horLavemp.Text = ""
        fechLavemp.Text = ""

        btnNew.Enabled = False
        btnIns.Enabled = True
        btnUpd.Enabled = False
        btnDel.Enabled = False

        horLavemp.Focus()
    End Sub
    Protected Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        Call execute("insert into lavado_empleado (Hora, Fecha, Id_lavado, Id_empleado) values ('" & horLavemp.Text & "', '" & fechLavemp.Text & "', " & ddIdlav.SelectedValue & ", " & ddIdemp.SelectedValue & ")")
        btnNew.Enabled = True
        btnIns.Enabled = False
        btnUpd.Enabled = True
        btnDel.Enabled = True

        contlavemp = 0
        Response.Redirect("lav_emp.aspx")
    End Sub
    Protected Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        Call execute("update lavado_empleado set Hora = '" & horLavemp.Text & "', Fecha = '" & fechLavemp.Text & "', Id_lavado = " & ddIdlav.SelectedValue & ", Id_empleado " & ddIdemp.SelectedValue & " where Id = " & idLavemp.Text & "")
        contlavemp = 0
        Response.Redirect("lav_emp.aspx")
    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If MsgBox("¿Está seguro que desea eliminar a este lavado_empleado?", MsgBoxStyle.YesNo, "¡Atencion!") = MsgBoxResult.Yes Then
            Call execute("delete from lavado_empleado where Id = " & idLavemp.Text & "")
            contlavemp = 0
            Response.Redirect("lav_emp.aspx")
        Else
            Exit Sub
        End If
    End Sub

    'Carga del validador
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
    End Sub
End Class