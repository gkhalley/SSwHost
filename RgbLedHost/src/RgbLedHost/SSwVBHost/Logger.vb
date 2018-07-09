Imports System
Imports System.IO
Imports Microsoft.SPOT
'
'/*-------------------------------------------------------------------------------+
'|
'| Copyright (c) 2012, Embedded-Lab. All Rights Reserved.
'|
'| Limited permission Is hereby granted to reproduce And modify this 
'| copyrighted material provided that this notice Is retained 
'| in its entirety in any such reproduction Or modification.
'|
'| Author: ANir
'| First Version Date: 2013/2/14
'+-------------------------------------------------------------------------------*/

Namespace IO
    Public Class Logger
        Public Shared Sub Log(ParamArray strings As Object())
            Dim message As String = String.Empty

            For i As Integer = 0 To strings.Length - 1
                message = message & strings(i).ToString() & " "
            Next

            WriteLog(message, StreamWriter, PrefixDateTime, LogToFile)
        End Sub

        Public Shared Sub Flush()
            If _streamWriter Is Nothing Then Return
            StreamWriter.Flush()
        End Sub

        Public Shared Sub Close()
            If _streamWriter Is Nothing Then Return
            StreamWriter.Flush()
            StreamWriter.Close()
            StreamWriter.Dispose()
        End Sub

        Private Shared Function GetDirectoryPath(ByVal trimmedDirectoryPath As String) As String
            If Not Directory.Exists(SDCardDirectory) Then Throw New Exception("SD card (directory) not found")
            Dim directoryPath As String = SDCardDirectory & Path.DirectorySeparatorChar & trimmedDirectoryPath
            If Not Directory.Exists(directoryPath) Then Directory.CreateDirectory(directoryPath)
            Return directoryPath
        End Function

        Private Shared Function GetFilePath(ByVal fullFileName As String, ByVal append As Boolean) As String
            If Not File.Exists(fullFileName) OrElse Not append Then
                File.Create(fullFileName)
            End If

            Return fullFileName
        End Function

        Private Shared Sub WriteLog(ByVal message As String, ByVal streamWriter As StreamWriter, ByVal addDateTime As Boolean, ByVal logToFile As Boolean)
            If addDateTime Then
                Dim current As DateTime = DateTime.Now
                message = "[" & current & ":" & current.Millisecond & "] " & message
            End If

            Debug.Print(message)
            If logToFile Then streamWriter.WriteLine(message)
        End Sub

        Public Shared Property PrefixDateTime As Boolean
        Public Shared Property LogToFile As Boolean
        Public Shared Property Append As Boolean

        Public Shared ReadOnly Property LogFilePath As String
            Get
                If _logFilePath Is Nothing Then _logFilePath = GetFilePath(GetDirectoryPath("Report") & Path.DirectorySeparatorChar & "Log.txt", Append)
                Return _logFilePath
            End Get
        End Property

        Private Shared ReadOnly Property SDCardDirectory As String
            Get
                Return "SD"
            End Get
        End Property

        Private Shared ReadOnly Property StreamWriter As StreamWriter
            Get
                If _streamWriter Is Nothing Then _streamWriter = New StreamWriter(LogFilePath, CBool(Append))
                Return _streamWriter
            End Get
        End Property

        Public Sub New(ByVal directoryName As String, ByVal fileNameWithExtension As String, ByVal Optional append As Boolean = True)
            CustomDirectoryName = directoryName
            CustomFileNameWithExtension = fileNameWithExtension
            CustomAppend = append
        End Sub

        Public Sub LogCustom(ParamArray strings As Object())
            Dim message As String = String.Empty

            For i As Integer = 0 To strings.Length - 1
                message = message & strings(i).ToString() & " "
            Next

            WriteLog(message, CustormStreamWriter, CustomPrefixDateTime, CustomLogToFile)
        End Sub

        Public Sub FlushCustomLogger()
            If CustormStreamWriter Is Nothing Then Return
            CustormStreamWriter.Flush()
        End Sub

        Public Sub CloseCustomStreamWriter()
            If CustormStreamWriter Is Nothing Then Return
            CustormStreamWriter.Flush()
            CustormStreamWriter.Close()
            CustormStreamWriter.Dispose()
        End Sub

        Private Property CustomDirectoryName As String
        Private Property CustomFileNameWithExtension As String
        Private Property CustomAppend As Boolean

        Private ReadOnly Property CustormStreamWriter As StreamWriter
            Get
                If _customStreamWriter Is Nothing Then _customStreamWriter = New StreamWriter(CustomFilePath, CustomAppend)
                Return _customStreamWriter
            End Get
        End Property

        Public ReadOnly Property CustomFilePath As String
            Get
                If CustomDirectoryName = String.Empty Then Throw New Exception("Custom directory cannot be blank")
                If CustomFileNameWithExtension = String.Empty Then Throw New Exception("File name cannot be blank")
                If _customLogFilePath Is Nothing Then _customLogFilePath = GetFilePath(GetDirectoryPath(CustomDirectoryName) & Path.DirectorySeparatorChar & CustomFileNameWithExtension, CustomAppend)
                Return _customLogFilePath
            End Get
        End Property

        Public Property CustomPrefixDateTime As Boolean
        Public Property CustomLogToFile As Boolean
        Private Shared _logFilePath As String
        Private Shared _streamWriter As StreamWriter
        Private _customStreamWriter As StreamWriter
        Private _customLogFilePath As String
    End Class
End Namespace
