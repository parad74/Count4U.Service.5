//await JSRuntime.InvokeVoidAsync("BlazorUniversity.setDocumentTitle", Title);
// менять заголовок 
var BlazorUniversity = BlazorUniversity || {};
BlazorUniversity.setDocumentTitle = function (title) {
    document.title = title;
};