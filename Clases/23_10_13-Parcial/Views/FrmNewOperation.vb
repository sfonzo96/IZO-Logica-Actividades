﻿Imports System.Data.SqlClient

Public Class FrmNewOperation
    Private arsQuantity As Decimal
    Private usdQuantity As Decimal
    Private Sub BtnConfirmOperation_Click(sender As Object, e As EventArgs) Handles BtnConfirmOperation.Click
        Try
            Dim dbOperationsService As New DbOperationsDataService()
            Dim dbSuccess As Boolean = dbOperationsService.AddOperation(FrmExchange.UsdValue, usdQuantity, arsQuantity)
            Dim fsOperationsService As New FsOperationsDataService()
            Dim fsSuccess As Boolean = fsOperationsService.AddOperation(FrmExchange.UsdValue, usdQuantity, arsQuantity)
            If Not (dbSuccess AndAlso fsSuccess) Then
                MessageBox.Show("La operación no pudo ser registrada.", "Estado de registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Throw New Exception("Error al registrar operación")
            Else
                MessageBox.Show("Operación registrada con éxito.", "Estado de registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ClearForm()
        Catch sqlEx As SqlException
            MessageBox.Show(sqlEx.Message, "DB error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnCalculateArsQuantity_Click(sender As Object, e As EventArgs) Handles BtnCalculateArsQuantity.Click
        Try
            If Not IsNumeric(TxtUsdQuantity.Text) Then
                MessageBox.Show("El valor ingresado no es válido.", "Entrada invalida", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                usdQuantity = CDec(TxtUsdQuantity.Text)
                arsQuantity = FrmExchange.UsdValue * usdQuantity
                TxtArsQuantity.Text = arsQuantity
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ClearForm()
        TxtUsdQuantity.Clear()
        TxtUsdQuantity.Focus()
        TxtArsQuantity.Clear()
    End Sub
End Class