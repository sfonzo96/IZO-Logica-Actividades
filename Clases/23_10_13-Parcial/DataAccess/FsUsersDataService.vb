﻿Imports System.IO

Public Class FsUsersDataService
    'Private ReadOnly FilePath As String = "C:\Deposito\Programación\IZO\MATERIAS\1° AÑO\LÓGICA Y ESTRUCTURA DE DATOS\ACTIVIDADES\Clases\Clases\23_10_13-Parcial\users.txt"
    Private workingDirectory As String = Environment.CurrentDirectory
    Private projectDirectory As String = Directory.GetParent(workingDirectory).Parent.Parent.FullName
    Private ReadOnly FilePath As String = Path.Combine(projectDirectory, "TxtData\users.txt")
    Public Function GetUser(username As String) As User

        If Not File.Exists(FilePath) Then
            Throw New Exception($"No se encontró el archivo en ¨{FilePath}")
        End If

        Dim user As User = Nothing
        Using reader As New StreamReader(FilePath)
            While Not reader.EndOfStream
                Dim userData As String = reader.ReadLine()
                If userData.Contains(username) Then
                    user = MapUserFromLine(userData)
                End If
            End While
        End Using

        If user Is Nothing Then
            Throw New Exception("No se pudo recuperar el usuario. Intentelo luego.")
        End If
        Return user
    End Function

    Public Shared Function MapUserFromLine(userData) As User
        Dim userProperties As String() = userData.Split(";")
        Dim user As New User(userProperties(0), userProperties(1), userProperties(2))
        Return user
    End Function
End Class