Imports System
Imports Microsoft.SPOT

Namespace SSwHost.Infrastructure
    Class Power
        Shared time As DateTime = New DateTime()

        Public Enum PeriodMax
            Second
            Minute
            FiveMinute
            FifeteenMinute
            Hour
        End Enum

        Private period As PeriodMax
        Shared current As Double
        Private ReadOnly Property defaultVoltage As Double = 120.0

        Public Sub New(ByVal time_ As DateTime, ByVal periodMax As PeriodMax, ByVal current_ As Double)
            time = time_
            period = periodMax
            current = current_
        End Sub

        Public Sub New(ByVal defaultVoltage_ As Double)
            defaultVoltage = defaultVoltage_
        End Sub
    End Class
End Namespace
