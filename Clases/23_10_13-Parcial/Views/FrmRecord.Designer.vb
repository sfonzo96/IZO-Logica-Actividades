﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecord
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        DGridRecord = New DataGridView()
        CType(DGridRecord, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DGridRecord
        ' 
        DGridRecord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DGridRecord.Location = New Point(12, 12)
        DGridRecord.Name = "DGridRecord"
        DGridRecord.RowTemplate.Height = 25
        DGridRecord.Size = New Size(776, 426)
        DGridRecord.TabIndex = 0
        ' 
        ' FrmRecord
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(DGridRecord)
        Name = "FrmRecord"
        Text = "FrmRecord"
        CType(DGridRecord, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DGridRecord As DataGridView
End Class
