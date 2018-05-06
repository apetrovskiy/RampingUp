
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub triggerButton_Click(sender As Object, e As EventArgs) Handles triggerButton.Click
        resultLabel.Text = "Button clicked!"
    End Sub
End Class
