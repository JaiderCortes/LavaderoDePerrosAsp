Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class cubrimiento
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Private Sub cubrimiento_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            cone = New SqlConnection
            cone.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lava_perro.mdf;Integrated Security=True"
            Dim sql As String = "select * from cubrimiento"
            Dim sen As New SqlDataAdapter(sql, cone)
            ds = New DataSet
            sen.Fill(ds, "cubrimiento")

            idCub.Text = ds.Tables("cubrimiento").Rows(0).Item("Id")
            empCub.Text = ds.Tables("cubrimiento").Rows(0).Item("Empleado_cubre")
            motCub.Text = ds.Tables("cubrimiento").Rows(0).Item("Motivo")
            fechCub.Text = ds.Tables("cubrimiento").Rows(0).Item("Fecha")

            Call cargarcombo("select * from empleado", ddEmp, "Id", "Nombre")
            ddEmp.SelectedValue = ds.Tables("cubrimiento").Rows(0).Item("Id_empleado")
        Catch ex As Exception
            MsgBox("Error de conexión: " + ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    'Primera línea de botones
    Protected Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        contcub = 0
        idCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Id")
        empCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Empleado_cubre")
        motCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Motivo")
        fechCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Fecha")
        ddEmp.SelectedValue = ds.Tables("cubrimiento").Rows(contcub).Item("Id_empleado")
    End Sub
    Protected Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        contcub = ds.Tables("cubrimiento").Rows.Count
        contcub = contcub - 1
        idCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Id")
        empCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Empleado_cubre")
        motCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Motivo")
        fechCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Fecha")
        ddEmp.SelectedValue = ds.Tables("cubrimiento").Rows(contcub).Item("Id_empleado")
    End Sub
    Protected Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        contcub = contcub - 1
        If contcub < 0 Then
            contcub = contcub + 1
            idCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Id")
            empCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Empleado_cubre")
            motCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Motivo")
            fechCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Fecha")
            ddEmp.SelectedValue = ds.Tables("cubrimiento").Rows(contcub).Item("Id_empleado")
        Else
            idCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Id")
            empCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Empleado_cubre")
            motCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Motivo")
            fechCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Fecha")
            ddEmp.SelectedValue = ds.Tables("cubrimiento").Rows(contcub).Item("Id_empleado")
        End If
    End Sub
    Protected Sub btnNex_Click(sender As Object, e As EventArgs) Handles btnNex.Click
        contcub = contcub + 1
        If contcub >= ds.Tables("cubrimiento").Rows.Count Then
            contcub = ds.Tables("cubrimiento").Rows.Count
            contcub = contcub - 1
        End If
        idCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Id")
        empCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Empleado_cubre")
        motCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Motivo")
        fechCub.Text = ds.Tables("cubrimiento").Rows(contcub).Item("Fecha")
        ddEmp.SelectedValue = ds.Tables("cubrimiento").Rows(contcub).Item("Id_empleado")
    End Sub

    'Segunda línea de botones
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        idCub.Text = ""
        empCub.Text = ""
        motCub.Text = ""
        fechCub.Text = ""

        btnNew.Enabled = False
        btnIns.Enabled = True
        btnUpd.Enabled = False
        btnDel.Enabled = False

        empCub.Focus()
    End Sub
    Protected Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        Call execute("insert into cubrimiento (Empleado_cubre, Motivo, Fecha, Id_empleado) values ('" & empCub.Text & "', '" & motCub.Text & "', '" & fechCub.Text & "', " & ddEmp.SelectedValue & ")")
        btnNew.Enabled = True
        btnIns.Enabled = False
        btnUpd.Enabled = True
        btnDel.Enabled = True

        contcub = 0
        Response.Redirect("cubrimiento.aspx")
    End Sub
    Protected Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        Call execute("update cubrimiento set Empleado_cubre = '" & empCub.Text & "', Motivo = '" & motCub.Text & "', Fecha = '" & fechCub.Text & "', Id_empleado = " & ddEmp.SelectedValue & " where Id = " & idCub.Text & "")
        contcub = 0
        Response.Redirect("cubrimiento.aspx")
    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If MsgBox("¿Está seguro que desea eliminar este cubrimiento?", MsgBoxStyle.YesNo, "¡Atencion!") = MsgBoxResult.Yes Then
            Call execute("delete from cubrimiento where Id = " & idCub.Text & "")
            contcub = 0
            Response.Redirect("cubrimiento.aspx")
        Else
            Exit Sub
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
    End Sub
End Class