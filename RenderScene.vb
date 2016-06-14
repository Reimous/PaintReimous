Imports System.Drawing.Drawing2D

Partial Public Class PaintReimous
    Private Sub renderScene()
        If ClientSize.Width > 0 Then 'Evitamos que pete cuando minimizamos
            backBuffer = New Bitmap(ClientSize.Width, ClientSize.Height)
            'If Not paused Then
            'graphicsEscenario = Graphics.FromImage(backBuffer)

            'graphicsCuadro = Graphics.FromImage(backBuffer)

            pbSurface.Image = Nothing

            'If started And lPuntosPot.Count > 0 And graficaPreparada Then
            'dibujaGrafica()
            'End If
            'If lPunto IsNot Nothing Then
            '    For Each pun As Punto In lPunto
            '        dibujaPunto(pun)
            '    Next

            'End If
            If lFigura IsNot Nothing Then
                For Each fig As Figura In lFigura
                    dibujaFigura(fig)
                Next
            End If
            


            If lUI IsNot Nothing Then
                For Each btn As UI In lUI
                    If btn.visible Then
                        dibujaUI(btn)
                    End If
                Next
            End If


            'tiempoTranscurrido()
            'Else
            'gamePaused()
            'End If

            pbSurface.Image = backBuffer

        End If
    End Sub

    'Private Sub dibujaPuntos()
    '    Try

    '        Dim g As Graphics = Graphics.FromImage(backBuffer)
    '        Dim tiempoAnt As Integer = 0

    '        For i = lPuntosPot.Count - 1 To 0 Step -1

    '            'If i = lPuntosPot.Count - 1 Then
    '            '    g.DrawString("Pot: " & lPuntosPot(i), New Font("Arial", 16), Brushes.White, 200, ClientSize.Height - 45)
    '            '    g.DrawString("Int: " & lPuntosInt(i), New Font("Arial", 16), Brushes.White, 300, ClientSize.Height - 45)
    '            'End If
    '            Dim calcPosX As Single
    '            calcPosX = puntoInferiorDerecha.X - (divTiempo * (((tiempo + tiempoAjustado + tiempoAjustadoPausa) * 1000) - lPuntosTime(i)))
    '            Dim calcPosXAnt As Single
    '            If calcPosX > puntoCeroGrafica.X And calcPosX < ClientSize.Width Then
    '                If i > 0 Then
    '                    calcPosXAnt = puntoInferiorDerecha.X - (divTiempo * (((tiempo + tiempoAjustado + tiempoAjustadoPausa) * 1000) - lPuntosTime(i - 1)))
    '                Else
    '                    calcPosXAnt = 0
    '                End If
    '                g.DrawRectangle(Pens.Violet, calcPosX, (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosNivel(i) * (puntoInferior.Y - puntoSuperior.Y) / 100), 2, 2)
    '                g.DrawRectangle(Pens.Yellow, calcPosX, (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosPot(i) * (puntoInferior.Y - puntoSuperior.Y) / maxPotencia), 2, 2)
    '                g.DrawRectangle(Pens.Coral, calcPosX, (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosInt(i) * (puntoInferior.Y - puntoSuperior.Y) / maxIntensidad), 2, 2)

    '                If Not CInt(lPuntosTime(i) / 1000) = tiempoAnt And Not i = lPuntosPot.Count - 1 Then
    '                    If CInt(lPuntosTime(i) / 1000) Mod arTiempos(indTiempos) / 10 = 0 Then
    '                        Dim tmpPosX As Single
    '                        tiempoAnt = CInt(lPuntosTime(i) / 1000)
    '                        If i = lPuntosTime.Count - 2 And tiempoAjustado = 0 Then
    '                            tmpPosX = puntoInferiorDerecha.X
    '                        Else
    '                            tmpPosX = calcPosX
    '                        End If
    '                        g.DrawString(tiempoAnt, New Font("Arial", 14), Brushes.White, tmpPosX, puntoCeroGrafica.Y + 5)
    '                    End If
    '                End If

    '                If i = lPuntosPot.Count - 1 Then
    '                    Dim tmpPosX As Single
    '                    If tiempoAjustado = 0 Then
    '                        tmpPosX = puntoInferiorDerecha.X
    '                    Else
    '                        tmpPosX = calcPosX
    '                    End If
    '                    g.DrawString(lPuntosPot(i), New Font("Arial", 16), Brushes.Yellow, tmpPosX, (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosPot(i) * (puntoInferior.Y - puntoSuperior.Y) / maxPotencia))
    '                    g.DrawString(lPuntosInt(i), New Font("Arial", 16), Brushes.Coral, tmpPosX, (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosInt(i) * (puntoInferior.Y - puntoSuperior.Y) / maxIntensidad))
    '                    g.DrawString(lPuntosNivel(i), New Font("Arial", 16), Brushes.Violet, tmpPosX, (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosNivel(i) * (puntoInferior.Y - puntoSuperior.Y) / 100))
    '                End If
    '                If i > 0 Then
    '                    If calcPosXAnt > puntoCeroGrafica.X Then

    '                    Else
    '                        calcPosXAnt = puntoCeroGrafica.X
    '                    End If
    '                    g.DrawLine(Pens.Yellow, calcPosX, _
    '                (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosPot(i) * (puntoInferior.Y - puntoSuperior.Y) / maxPotencia), _
    '                calcPosXAnt, _
    '                (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosPot(i - 1) * (puntoInferior.Y - puntoSuperior.Y) / maxPotencia))

    '                    g.DrawLine(Pens.Coral, calcPosX, _
    '                    (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosInt(i) * (puntoInferior.Y - puntoSuperior.Y) / maxIntensidad), _
    '                    calcPosXAnt, _
    '                    (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosInt(i - 1) * (puntoInferior.Y - puntoSuperior.Y) / maxIntensidad))

    '                    g.DrawLine(Pens.Violet, calcPosX, _
    '                    (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosNivel(i) * (puntoInferior.Y - puntoSuperior.Y) / 100), _
    '                    calcPosXAnt, _
    '                    (ClientSize.Height - (ClientSize.Height - puntoInferior.Y)) - (lPuntosNivel(i - 1) * (puntoInferior.Y - puntoSuperior.Y) / 100))
    '                End If
    '            End If
    '        Next
    '        g.Dispose()
    '    Catch ex As Exception
    '        log.escribeLog("Error al dibujar los puntos: " & ex.Message)
    '    End Try
    'End Sub

    'Private Sub dibujaGrafica()
    '    Dim g As Graphics = Graphics.FromImage(backBuffer)
    '    Dim drawFont As New Font("Arial", 16)
    '    Dim drawFont2 As New Font("Arial", 12)
    '    Dim penGrafica As Pen = New Pen(Color.FromArgb(255, 255, 255, 255), 5)
    '    Dim penGraficaMenor As Pen = New Pen(Color.FromArgb(255, 0, 255, 0), 1)

    '    g.DrawLine(penGrafica, puntoSuperior.X, puntoSuperior.Y, puntoInferior.X, puntoInferior.Y)
    '    g.DrawLine(penGrafica, puntoInferior.X, puntoInferior.Y, puntoInferiorDerecha.X, puntoInferiorDerecha.Y)


    '    g.DrawLine(penGrafica, puntoSuperior.X + 60, puntoSuperior.Y, puntoInferior.X + 60, puntoInferior.Y)
    '    g.DrawLine(penGrafica, puntoSuperior.X + 100, puntoSuperior.Y, puntoCeroGrafica.X, puntoInferior.Y)

    '    g.DrawString("Pot", drawFont, Brushes.Yellow, puntoSuperior.X - 60, puntoSuperior.Y - 60)
    '    g.DrawString("(W)", drawFont, Brushes.Yellow, puntoSuperior.X - 60, puntoSuperior.Y - 30)
    '    g.DrawString("Int", drawFont, Brushes.Coral, puntoSuperior.X + 10, puntoSuperior.Y - 60)
    '    g.DrawString("(mA)", drawFont, Brushes.Coral, puntoSuperior.X + 10, puntoSuperior.Y - 30)
    '    g.DrawString("Nivel", drawFont, Brushes.Violet, puntoSuperior.X + 60, puntoSuperior.Y - 40)
    '    'g.DrawString("TAjustado: " & tiempoAjustado, drawFont, Brushes.White, 500, 500)
    '    'g.DrawString("TPausa: " & tiempoAjustadoPausa, drawFont, Brushes.White, 500, 550)
    '    For i = 0 To UBound(arPotencia)
    '        If i < UBound(arPotencia) Then
    '            g.DrawString(arPotencia(i), drawFont, Brushes.Yellow, puntoSuperior.X - 50, arPosicionVerticalPotencia(i))
    '            g.DrawLine(Pens.White, puntoSuperior.X, arPosicionVerticalPotencia(i), puntoSuperior.X - 15, arPosicionVerticalPotencia(i))
    '        End If
    '        'g.DrawLine(penGraficaMenor, puntoSuperior.X + 65, arPosicionVertical(i), puntoInferiorDerecha.X, arPosicionVertical(i))
    '    Next
    '    For i = 0 To UBound(arIntensidad)
    '        Dim esconder As Integer
    '        If tratamiento.Substring(0, 1) = "R" Then
    '            esconder = 0
    '        Else
    '            esconder = 2
    '        End If
    '        If i < UBound(arIntensidad) - esconder Then
    '            g.DrawString(arIntensidad(i), drawFont, Brushes.Coral, puntoSuperior.X + 5, arPosicionVerticalIntensidad(i))
    '            g.DrawLine(Pens.White, puntoSuperior.X + 60, arPosicionVerticalIntensidad(i), puntoSuperior.X + 45, arPosicionVerticalIntensidad(i))
    '        End If
    '    Next
    '    For i = 0 To UBound(arNivel)
    '        If i = UBound(arNivel) Then
    '            g.DrawString(arNivel(i), drawFont2, Brushes.Violet, puntoSuperior.X + 65, arPosicionVerticalNivel(i))
    '        Else
    '            g.DrawString(arNivel(i), drawFont2, Brushes.Violet, puntoSuperior.X + 70, arPosicionVerticalNivel(i))
    '        End If
    '        g.DrawLine(Pens.White, puntoCeroGrafica.X, arPosicionVerticalNivel(i), puntoCeroGrafica.X - 15, arPosicionVerticalNivel(i))
    '    Next

    '    g.DrawString("0", drawFont, Brushes.Red, puntoInferior.X + 10, puntoInferior.Y + 10)

    '    'For i = 0 To lTiempo.Count - 1
    '    '    g.DrawString(lTiempo(i), drawFont, Brushes.White, arPosicionHorizontal(i), puntoInferior.Y)
    '    '    g.DrawLine(Pens.White, arPosicionHorizontal(i), puntoInferior.Y, arPosicionHorizontal(i), puntoInferior.Y - 500)
    '    'Next

    '    g.DrawString("Tiempo: " & CInt(tiempo), drawFont, Brushes.White, 20, 110)
    '    g.DrawString("Tratamiento: " & tratamiento, drawFont, Brushes.White, 20, 20)
    '    g.DrawString("Hora inicio: " & horaIni.Hour & ":" & horaIni.Minute & ":" & horaIni.Second, drawFont, Brushes.White, 20, 50)
    '    g.DrawString("Hora fin: " & horaFin.Hour & ":" & horaFin.Minute & ":" & horaFin.Second, drawFont, Brushes.White, 250, 50)
    '    g.DrawString("Cliente: ", drawFont, Brushes.White, 20, 80)
    '    'g.DrawString("Máximo pot: " & maxValPot, drawFont, Brushes.White, 400, ClientSize.Height - 30)
    '    'g.DrawString("Máximo int: " & maxValInt, drawFont, Brushes.White, 200, ClientSize.Height - 30)


    '    g.Dispose()
    'End Sub

    Private Sub dibujaFigura(ByVal figura As Figura)
        'If figura.puntoLocalizacion.X <= ClientSize.Width And figura.puntoLocalizacion.Y >= 0 And figura.puntoLocalizacion.Y <= ClientSize.Height And figura.puntoLocalizacion.X >= 0 Then

        Dim g As Graphics = Graphics.FromImage(backBuffer)
        For i = 0 To figura.lPunto.Count - 1
            g.FillRectangle(Brushes.White, figura.lPunto(i).puntoLocalizacion.X - 5, figura.lPunto(i).puntoLocalizacion.Y - 5, 10, 10)
            If i = figura.lPunto.Count - 1 And enProceso And "f" & lFigura.Count - 1 = figura.id And arHerramienta(indiceHerramienta) = "line" Then
                g.DrawLine(Pens.Pink, figura.lPunto(i).puntoLocalizacion.X, figura.lPunto(i).puntoLocalizacion.Y, mloc.X, mloc.Y)
            End If
        Next
        For i = 0 To figura.lPunto.Count - 2
            g.DrawLine(Pens.Pink, figura.lPunto(i).puntoLocalizacion.X, figura.lPunto(i).puntoLocalizacion.Y, figura.lPunto(i + 1).puntoLocalizacion.X, figura.lPunto(i + 1).puntoLocalizacion.Y)
        Next
        g.Dispose()
        'End If
    End Sub
    Private Sub dibujaPunto(ByVal punto As Punto)
        If punto.puntoLocalizacion.X <= ClientSize.Width And punto.puntoLocalizacion.Y >= 0 And punto.puntoLocalizacion.Y <= ClientSize.Height And punto.puntoLocalizacion.X >= 0 Then

            Dim g As Graphics = Graphics.FromImage(backBuffer)
            'g.DrawRectangle(Pens.White, punto.puntoLocalizacion.X, punto.puntoLocalizacion.Y, 10, 10)
            g.FillRectangle(Brushes.White, punto.puntoLocalizacion.X - 5, punto.puntoLocalizacion.Y - 5, 10, 10)
            g.Dispose()
        End If
    End Sub
    'Private Sub dibujaEnemy(ByVal enem As Enemy)
    '    If enem.puntoLocalizacion.X <= ClientSize.Width And enem.puntoLocalizacion.Y + enem.size.Height >= 0 And enem.puntoLocalizacion.Y <= ClientSize.Height And enem.puntoLocalizacion.X + enem.size.Width >= 0 Then

    '        Dim g As Graphics = Graphics.FromImage(backBuffer)
    '        Dim vidaPen As Pen
    '        Dim porcentaje As Single = (enem.vida * 100) / enem.vidaTotal
    '        If porcentaje >= 66 Then
    '            vidaPen = New Pen(Color.FromArgb(255, 0, 255, 0), 5)
    '        ElseIf porcentaje >= 33 Then
    '            vidaPen = New Pen(Color.FromArgb(255, 255, 255, 0), 5)
    '        Else
    '            vidaPen = New Pen(Color.FromArgb(255, 255, 0, 0), 5)
    '        End If


    '        'g.DrawRectangle(Pens.Blue, enem.rObjeto)

    '        'g.DrawEllipse(Pens.Yellow, enem.rAtaque)


    '        g.FillRectangle(enem.tBrush, enem.rObjeto)


    '        If enem.vida < enem.vidaTotal Then
    '            g.DrawLine(vidaPen, enem.puntoLocalizacion.X, enem.puntoLocalizacion.Y - 5, enem.puntoLocalizacion.X + enem.size.Width * porcentaje / 100, enem.puntoLocalizacion.Y - 5)
    '        End If

    '        g.Dispose()
    '    End If
    'End Sub
    'Private Sub dibujaProy(ByVal proy As Proyectil)
    '    Dim g As Graphics = Graphics.FromImage(backBuffer)
    '    Dim brush As Brush
    '    'g.DrawRectangle(Pens.PeachPuff, proy.rObjeto)
    '    If proy.tipo = "invader" Then
    '        brush = Brushes.Yellow
    '    ElseIf proy.tipo = "building" Then
    '        brush = Brushes.Aqua
    '    Else
    '        brush = Brushes.Black
    '    End If
    '    g.FillRectangle(brush, proy.rObjeto)
    '    g.Dispose()
    'End Sub
    Private Sub dibujaUI(ByVal btn As UI)
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.White)
        Dim g As Graphics = Graphics.FromImage(backBuffer)
        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        If btn.mouseOver Then
            g.FillRectangle(Brushes.Azure, btn.rObjeto)
            g.DrawString(btn.texto, drawFont, Brushes.Black, btn.puntoLocalizacionCentrado.X, btn.puntoLocalizacionCentrado.Y, stringFormat)
        Else
            g.DrawString(btn.texto, drawFont, drawBrush, btn.puntoLocalizacionCentrado.X, btn.puntoLocalizacionCentrado.Y, stringFormat)
        End If
        g.DrawRectangle(Pens.PeachPuff, btn.rObjeto)

        If arHerramienta(indiceHerramienta) = btn.id Then
            g.FillRectangle(Brushes.Gray, btn.rObjeto)
            g.DrawString(btn.texto, drawFont, Brushes.Black, btn.puntoLocalizacionCentrado.X, btn.puntoLocalizacionCentrado.Y, stringFormat)
        End If

        If btn.tBrush IsNot Nothing Then
            g.FillRectangle(btn.tBrush, btn.rObjeto)
        End If
        g.Dispose()
    End Sub
    Private Sub dibujaEnPuntero()
        'If construcSel IsNot Nothing Then
        '    Dim g As Graphics = Graphics.FromImage(backBuffer)
        '    If construcSel = "Building" Then

        '        'brushBuilding(0).TranslateTransform(mloc.X - posMouseAnterior.X, mloc.Y - posMouseAnterior.Y, MatrixOrder.Prepend)

        '        g.FillRectangle(brushPuntero, mloc.X - medidaBuilding.Width / 2, mloc.Y - medidaBuilding.Height / 2, medidaBuilding.Width, medidaBuilding.Height)
        '    End If
        'End If
    End Sub

    Private Sub escalaImagenObjeto(ByVal w As Integer, ByVal h As Integer, ByVal bitmapOriginal As Bitmap, ByRef brush As TextureBrush, ByVal wrap As WrapMode)
        ' Make a bitmap for the result.
        Dim bm_dest As New Bitmap(w, h)

        ' Make a Graphics object for the result Bitmap.
        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

        ' Copy the source image into the destination bitmap.
        gr_dest.DrawImage(bitmapOriginal, 0, 0, bm_dest.Width, bm_dest.Height)
        brush = New TextureBrush(bm_dest)
        brush.WrapMode = wrap

        bm_dest.Dispose()
        gr_dest.Dispose()
    End Sub

End Class
