Imports System.Threading

Public Class PaintReimous

#Region "Declaraciones"
    Public Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vKey As Int32) As UShort
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
    Dim timer As Stopwatch
    Dim backBuffer As Bitmap
    Dim interval, startTick As Integer
    Dim gameover, iniHerramienta, clicked, enProceso, overUI As Boolean
    Dim arHerramienta() As String = {"nothing", "line", "move"} 'array con las herramientas
    Dim arCountHerramienta() As Integer = {1, 1, 1} 'array donde anotamos la cantidad de figuras de cada herramienta
    'Dim lPunto As List(Of Punto) 'lista de puntos temporal donde se almacenan los puntos y se pasa al objeto figura para almacenar esta lista
    Dim lFigura As List(Of Figura) 'lista de figuras (una figura esta formada por puntos)
    Dim lUI As List(Of UI) 'lista de objetos de la interfaz 
    Dim mloc As PointF
    Dim puntoRefUI As Point
    Dim puntoSel As String
    Dim indiceHerramienta, countPuntos, countFiguras As Integer 'indicePunto As Integer

    'Dim log As New Log
#End Region
#Region "Eventos Form"""
    Private Sub PaintReimous_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True

        Me.ClientSize = New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)

        backBuffer = New Bitmap(ClientSize.Width, ClientSize.Height)

        Me.CenterToScreen()
        Me.WindowState = FormWindowState.Maximized
        'Me.MaximizeBox = False

        interval = 1 '16 = 60fps 33 = 30fps
        timer = New Stopwatch()

        'tiempoMuestras = 1000 'En milisegundos

        Timer1.Interval = interval



        lUI = New List(Of UI)
        'lPunto = New List(Of Punto)
        lFigura = New List(Of Figura)

        indiceHerramienta = 0
        countPuntos = 0
        countFiguras = 0
        iniHerramienta = True
        clicked = False
        enProceso = False
        overUI = False
        puntoSel = ""

        iniUI()
    End Sub
    Private Sub configExtra()
        Me.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, True) ' True is better
        Me.SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True) ' True is better
        ' Disable the on built PAINT event. We dont need it with a renderloop.
        ' The form will no longer refresh itself
        ' we will raise the paint event ourselves from our renderloop.
        Me.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, False) ' False is better

    End Sub
    Private Sub PantallaPrincipal_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        GameLoop()
    End Sub
    Private Sub iniUI()

        Dim btnLine As New UI(ClientSize.Width - 300, 0, 100, 50, "Tipo1", "line", "Line")
        btnLine.visible = True
        lUI.Add(btnLine)
        Dim btnMove As New UI(ClientSize.Width - 200, 0, 100, 50, "Tipo1", "move", "Move")
        btnMove.visible = True
        lUI.Add(btnMove)
        'Dim btnLeftFastTime As New UI(puntoRefUI.X, puntoRefUI.Y, 30, 20, "Tipo1", "leftFastTime", "<<")
        'btnLeftFastTime.visible = True
        'lUI.Add(btnLeftFastTime)
        'Dim btnRightFastTime As New UI(puntoRefUI.X + 90, puntoRefUI.Y, 30, 20, "Tipo1", "rightFastTime", ">>")
        'btnRightFastTime.visible = True
        'lUI.Add(btnRightFastTime)
        'Dim btnLeftSlowTime As New UI(puntoRefUI.X + 30, puntoRefUI.Y, 30, 20, "Tipo1", "leftSlowTime", "<")
        'btnLeftSlowTime.visible = True
        'lUI.Add(btnLeftSlowTime)
        'Dim btnRightSlowTime As New UI(puntoRefUI.X + 60, puntoRefUI.Y, 30, 20, "Tipo1", "rightSlowTime", ">")
        'btnRightSlowTime.visible = True
        'lUI.Add(btnRightSlowTime)
        'Dim btnFinal As New UI(puntoRefUI.X + 120, puntoRefUI.Y, 30, 20, "Tipo1", "final", ">l")
        'btnFinal.visible = True
        'lUI.Add(btnFinal)
        'Dim btnInicio As New UI(puntoRefUI.X - 30, puntoRefUI.Y, 30, 20, "Tipo1", "inicio", "l<")
        'btnInicio.visible = True
        'lUI.Add(btnInicio)
        'Dim btnPausa As New UI(puntoRefUI.X + 45, puntoRefUI.Y + 20, 30, 20, "Tipo1", "pausa", "ll")
        'btnPausa.visible = True
        'lUI.Add(btnPausa)
        'Dim btnTiempos As New UI(ClientSize.Width - 400, 10, 80, 20, "Tipo1", "tiempos", arTiempos(indTiempos))
        'btnTiempos.visible = True
        'lUI.Add(btnTiempos)
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If GetAsyncKeyState(Convert.ToInt32(Keys.Escape)) Then
            'Dim r As DialogResult = MessageBox.Show("Quiere cerrar la aplicación?", "Cerrar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            'If r = Windows.Forms.DialogResult.OK Then
            '    End
            'End If
        End If
        If GetAsyncKeyState(1) Then
            leftClick()
        ElseIf GetAsyncKeyState(2) Then
            rightClick()
        Else
            'Control para evitar pulsar el botón varias veces al dejar el ratón pulsado
            For Each btn As UI In lUI
                If btn.enUso Then
                    btn.enUso = False
                End If
            Next
            If clicked Then
                clicked = False
            End If
        End If
        'If GetAsyncKeyState(Keys.ShiftKey) Then
        '    shiftDown = True
        'Else
        '    shiftDown = False
        'End If
    End Sub
    Private Sub leftClick()
        If Not clicked Then
            clicked = True
            If Not overUI Then
                Select Case arHerramienta(indiceHerramienta)
                    Case "line"
                        enProceso = True

                        Dim punto As New Punto(mloc.X, mloc.Y, arCountHerramienta(1), "p" & countPuntos)
                        countPuntos += 1
                        If iniHerramienta Then
                            iniHerramienta = False

                            Dim figura As New Figura("f" & countFiguras)
                            countFiguras += 1
                            lFigura.Add(figura)
                        End If
                        lFigura(lFigura.Count - 1).addPunto(punto)
                    Case "move"
                        If puntoSel = "" Then
                            overPunto()
                        Else
                            puntoSel = ""
                        End If

                End Select
            End If
            For Each btn In lUI
                If btn.mouseOver Then
                    funcionBtnUI(btn)
                End If
            Next
        End If
    End Sub
    Private Sub overPunto()
        For Each fig As Figura In lFigura
            For i = 0 To fig.lPunto.Count - 1
                If mloc.X >= fig.lPunto(i).puntoLocalizacion.X - 5 And mloc.X <= fig.lPunto(i).puntoLocalizacion.X + 5 And mloc.Y >= fig.lPunto(i).puntoLocalizacion.Y - 5 And mloc.Y <= fig.lPunto(i).puntoLocalizacion.Y + 5 Then
                    puntoSel = fig.lPunto(i).id
                End If
            Next
        Next
    End Sub
    Private Sub rightClick()
        If enProceso And arHerramienta(indiceHerramienta) = "line" Then
            If Not clicked Then
                clicked = True
                enProceso = False
                arCountHerramienta(indiceHerramienta) += 1
                'indiceHerramienta = 0
                iniHerramienta = True
            End If
        End If
    End Sub
    Private Sub funcionBtnUI(ByVal btn As UI)
        Select Case btn.id
            Case "line"
                If Not btn.enUso Then
                    btn.enUso = True
                    indiceHerramienta = 1
                End If
            Case "move"
                If Not btn.enUso Then
                    btn.enUso = True
                    indiceHerramienta = 2
                End If
        End Select
    End Sub

    Private Sub TowerDefense_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Dim r As DialogResult = MessageBox.Show("Quiere cerrar la aplicación?", "Cerrar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        'If r = Windows.Forms.DialogResult.OK Then
        End
        'End If
    End Sub
    Private Sub pbSurface_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbSurface.MouseMove
        'If Not paused Then
        '    'Invalidate(New Rectangle(CInt(mloc.X * sf), CInt(mloc.Y * sf), CInt((sqrSize + 2) * sf), CInt((sqrSize + 2) * sf)))
        '    'mloc.X = CInt(e.X / sf)
        '    'mloc.Y = CInt(e.Y / sf)


        'posMouseAnterior = New PointF(mloc.X, mloc.Y) 'Comentado para escribirlo cuando cambio de cuadro
        mloc.X = CSng(e.X)
        mloc.Y = CSng(e.Y)
        'If brushPuntero IsNot Nothing Then 'And cuadroOverActual IsNot Nothing Then

        '    'If cuadroOverActual.id <> cuadroOverAnterior.id Then
        '    brushPuntero.TranslateTransform(mloc.X - posMouseAnterior.X, mloc.Y - posMouseAnterior.Y, MatrixOrder.Prepend) 'En posición ratón

        '    'brushPuntero.TranslateTransform(cuadroOverActual.A.X - cuadroOverAnterior.A.X, cuadroOverActual.A.Y - cuadroOverAnterior.A.Y, MatrixOrder.Prepend) 'En posición centro cuadroOverActual

        '    'End If
        'End If
        ''ToolStripLabel3.Text = "distancia centro X: " & ClientSize.Width / 2 - cuadroOverActual.A.X & " Y: " & ClientSize.Height / 2 - cuadroOverActual.A.Y

        If puntoSel IsNot "" Then
            For Each fig As Figura In lFigura
                For i = 0 To fig.lPunto.Count - 1
                    If fig.lPunto(i).id = puntoSel Then
                        fig.lPunto(i).puntoLocalizacion = mloc
                    End If
                Next
            Next
        End If

        calcInUI()

        ''Invalidate(New Rectangle(CInt(mloc.X * sf), CInt(mloc.Y * sf), CInt((sqrSize + 2) * sf), CInt((sqrSize + 2) * sf)))
        ''Invalidate() 'Comment out this, and uncomment the other two above to do partial area updates   COMENTADO YA QUE CREO QUE NO ES NECESARIO
        'End If
    End Sub
    Private Function calcInUI()
        Dim dentro As Boolean = False
        If lUI IsNot Nothing Then
            For Each btn In lUI
                If btn.visible Then
                    If mloc.X >= btn.puntoLocalizacion.X And mloc.X <= btn.puntoLocalizacion.X + btn.size.Width _
                    And mloc.Y >= btn.puntoLocalizacion.Y And mloc.Y <= btn.puntoLocalizacion.Y + btn.size.Height Then
                        dentro = True
                        overUI = True
                        'cuadroOverActual = Nothing
                        btn.mouseOver = True
                    Else
                        overUI = False
                        btn.mouseOver = False

                    End If
                End If
            Next

        End If
        Return dentro
    End Function
#End Region
#Region "Otros"
    Private Sub sonido(ByVal ruta As String)
        Dim sonidoT As New Thread(AddressOf procesaSonido)
        sonidoT.Start(ruta)
    End Sub
    Private Sub procesaSonido(ByVal ruta As String)
        mciSendString("close Sonido", Nothing, 0, 0)
        mciSendString("open " & """" & ruta & """" & " type mpegvideo alias Sonido", String.Empty, 0, 0)
        mciSendString("play Sonido", String.Empty, 0, 0)
        mciSendString("setaudio Sonido volume to " & 500, Nothing, 0, 0)
    End Sub
    Private Sub temporizador(ByVal tObjeto As tObjeto)
        Dim tTime As New Thread(AddressOf procesoTemporizador)
        tTime.Start(tObjeto)
    End Sub
    Private Sub procesoTemporizador(ByVal tObjeto As tObjeto)
        Dim tmpTimer As New Stopwatch

        tmpTimer.Start()
        Dim counter As Integer = 0
        tObjeto.enUso = True
        Do While (tObjeto.tiempo > counter)
            startTick = timer.ElapsedMilliseconds
            counter = CInt(tmpTimer.ElapsedMilliseconds)
            Do While timer.ElapsedMilliseconds - startTick < interval

            Loop
        Loop
        tObjeto.enUso = False
    End Sub
    Private Sub stopGame()
        timer.Stop()
    End Sub
    Private Sub startGame()
        timer.Start()
    End Sub
#End Region

End Class
