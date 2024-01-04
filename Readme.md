## Controller 
- Là một lớp kế thừa từ lớp Controller 
- Action trong controller là một phương thức public (ko được static)
- Action trả về bất kì kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject  vào controller qua hàm tạo
## View
- là file cshtml
- View cho Action ưu tiên View/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View

option.ViewLocationFormat.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);

## Truyền dữ liệu sang View

-Model
-ViewData
-ViewBag
-TempData