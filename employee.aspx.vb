Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class employee
    Inherits System.Web.UI.Page
    Public ds As DataSet
    Private Sub employee_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            cone = New SqlConnection
            cone.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lava_perro.mdf;Integrated Security=True"
            Dim sql As String = "select * from empleado"
            Dim sen As New SqlDataAdapter(sql, cone)
            ds = New DataSet
            sen.Fill(ds, "empleado")

            idEmp.Text = ds.Tables("empleado").Rows(0).Item("Id")
            nomEmp.Text = ds.Tables("empleado").Rows(0).Item("Nombre")
            nacEmp.Text = ds.Tables("empleado").Rows(0).Item("Fecha_nacimiento")
            emaEmp.Text = ds.Tables("empleado").Rows(0).Item("Email")
        Catch ex As Exception
            MsgBox("Error de conexión: " + ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    'Primera línea de botones
    Protected Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        contemp = 0
        idEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Id")
        nomEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Nombre")
        nacEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Fecha_nacimiento")
        emaEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Email")
    End Sub
    Protected Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        contemp = ds.Tables("empleado").Rows.Count
        contemp = contemp - 1
        idEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Id")
        nomEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Nombre")
        nacEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Fecha_nacimiento")
        emaEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Email")
    End Sub
    Protected Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        contemp = contemp - 1
        If contemp < 0 Then
            contemp = contemp + 1
            idEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Id")
            nomEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Nombre")
            nacEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Fecha_nacimiento")
            emaEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Email")
        Else
            idEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Id")
            nomEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Nombre")
            nacEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Fecha_nacimiento")
            emaEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Email")
        End If
    End Sub
    Protected Sub btnNex_Click(sender As Object, e As EventArgs) Handles btnNex.Click
        contemp = contemp + 1
        If contemp >= ds.Tables("empleado").Rows.Count Then
            contemp = ds.Tables("empleado").Rows.Count
            contemp = contemp - 1
        End If
        idEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Id")
        nomEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Nombre")
        nacEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Fecha_nacimiento")
        emaEmp.Text = ds.Tables("empleado").Rows(contemp).Item("Email")
    End Sub

    'Segunda línea de botones
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        idEmp.Text = ""
        nomEmp.Text = ""
        nacEmp.Text = ""
        emaEmp.Text = ""

        btnNew.Enabled = False
        btnIns.Enabled = True
        btnUpd.Enabled = False
        btnDel.Enabled = False

        nomEmp.Focus()
    End Sub
    Protected Sub btnIns_Click(sender As Object, e As EventArgs) Handles btnIns.Click
        Call execute("insert into empleado (Nombre, Fecha_nacimiento, Email) values ('" & nomEmp.Text & "', '" & nacEmp.Text & "', '" & emaEmp.Text & "')")
        btnNew.Enabled = True
        btnIns.Enabled = False
        btnUpd.Enabled = True
        btnDel.Enabled = True

        contemp = 0
        Response.Redirect("employee.aspx")
    End Sub
    Protected Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        Call execute("update empleado set Nombre = '" & nomEmp.Text & "', Fecha_nacimiento = '" & nacEmp.Text & "', Email = '" & emaEmp.Text & "' where Id = " & idEmp.Text & "")
        contemp = 0
        Response.Redirect("employee.aspx")
    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If MsgBox("¿Está seguro que desea eliminar a este empleado?", MsgBoxStyle.YesNo, "¡Atencion!") = MsgBoxResult.Yes Then
            Call execute("delete from empleado where Id = " & idEmp.Text & "")
            contemp = 0
            Response.Redirect("employee.aspx")
        Else
            Exit Sub
        End If
    End Sub

    'Carga del validador
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
    End Sub
End Class