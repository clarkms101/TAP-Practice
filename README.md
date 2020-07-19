# TAP-Practice
非同步練習

## 常用語法
Task.Run( () => 工作() );
await Task.Delay(毫秒);

## Task 回傳
* Task<Result> - 回傳Task裡面的值
* Task - 回傳Task
  
## Task 取消
```csharp
var cts = new CancellationTokenSource();
cts.Cancel(); // 需要在await之前作取消
```
## Task 例外
https://dotblogs.com.tw/sean_liao/2018/01/09/taskexceptionshandling

## Task 平行
https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/concepts/async/how-to-make-multiple-web-requests-in-parallel-by-using-async-and-await
async Task.Run()
async Task.Run()
async Task.Run()
...
