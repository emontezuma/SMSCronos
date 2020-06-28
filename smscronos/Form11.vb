Public Class Form11
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        MemoEdit1.Text = ""
        MemoEdit2.Text = ""
        MemoEdit3.Text = ""
        MemoEdit1.Focus()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Memo1 = MemoEdit1.Text
        Memo2 = MemoEdit2.Text
        Memo3 = MemoEdit3.Text
        Me.Close()
    End Sub

    Private Sub MemoEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles MemoEdit3.EditValueChanged

    End Sub

    Private Sub MemoEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles MemoEdit2.EditValueChanged

    End Sub

    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles LabelControl1.Click

    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MemoEdit1.Text = Memo1
        MemoEdit2.Text = Memo2
        MemoEdit3.Text = Memo3
    End Sub
End Class