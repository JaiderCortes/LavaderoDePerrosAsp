Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Module modulo_ejecuciones
    Public contcli As Integer
    Public contcub As Integer
    Public contemp As Integer
    Public contlav As Integer
    Public contlavemp As Integer
    Public contperro As Integer
    Public contprod As Integer
    Public contprodlav As Integer

    Public cone As SqlConnection

    Public Function execute(consulta As String)
        Try
            If cone.State = ConnectionState.Open Then
                Dim cmd As SqlCommand
                cmd = New SqlCommand
                cmd.Connection = cone
                cmd.CommandText = consulta
                cmd.ExecuteNonQuery()
                cone.Close()
                MsgBox("Buen trabajo, la sentencia fue ejecutada correctamente", MsgBoxStyle.Information, "Perfecto")
            Else
                cone.Open()
                Dim cmd As SqlCommand
                cmd = New SqlCommand
                cmd.Connection = cone
                cmd.CommandText = consulta
                cmd.ExecuteNonQuery()
                cone.Close()
                MsgBox("Buen trabajo, la sentencia fue ejecutada correctamente", MsgBoxStyle.Information, "Perfecto")
            End If
        Catch ex As Exception
            MsgBox("Error en la ejecución de la sentencia" + ex.Message, MsgBoxStyle.Exclamation, "Error ")
        End Try
    End Function

    Public Sub cargarcombo(sentenciasql As String, comb As DropDownList, valor As String, mostrar As String)
        Dim datatab As New DataTable
        Dim dataada As New SqlDataAdapter(sentenciasql, cone)
        dataada.SelectCommand.Connection = cone
        dataada.SelectCommand.CommandText = sentenciasql
        dataada.Fill(datatab)

        If datatab.Rows.Count >= 0 Then
            comb.DataSource = datatab
            comb.DataValueField = datatab.Columns(valor).ToString
            comb.DataTextField = datatab.Columns(mostrar).ToString
            comb.DataBind()
        End If
    End Sub

End Module
