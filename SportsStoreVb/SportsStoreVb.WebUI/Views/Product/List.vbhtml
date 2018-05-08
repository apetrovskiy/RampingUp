@ModelType IEnumerable(Of SportsStoreVb.Domain.SportsStoreVb.Domain.Entities.Product)
@Code
    ViewData("Title") = "Products"
End Code

@For Each p In Model
    @<div>
        <h3>@p.Name</h3>
        @p.Description
        <h4>@p.Price.ToString("c")</h4>
    </div>
Next

