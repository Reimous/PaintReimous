Partial Public Class PaintReimous
    Private Sub GameLoop()

        Timer.Start()
        Timer1.Start()
        'gestionWindow()

        Do While (gameover = False)
            startTick = timer.ElapsedMilliseconds





            'If Not paused Then

            
            logicaAplicacion()


            'End If

            renderScene()

            Application.DoEvents()

            ' Forzamos una recolección de elementos no utilizados
            GC.Collect()
            GC.WaitForPendingFinalizers()

            Do While timer.ElapsedMilliseconds - startTick < interval

            Loop
        Loop

        Dim result As DialogResult
        result = MessageBox.Show("Volver a intentar?", "Game Ovaer", MessageBoxButtons.YesNo, MessageBoxIcon.None)
    End Sub

    Private Sub logicaAplicacion()
  
    End Sub
End Class
