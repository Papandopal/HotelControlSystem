@echo off
chcp 65001 > nul
echo Поиск файлов .cs и подсчет строк...
echo --------------------------------------------------

powershell -NoProfile -Command ^
    "$total = 0; " ^
    "Get-ChildItem -Recurse -Filter *.cs -ErrorAction SilentlyContinue | ForEach-Object { " ^
        "$lines = (Get-Content $_.FullName | Measure-Object -Line).Lines; " ^
        "$total += $lines; " ^
        "Write-Host ('{0,-50} : {1} строк' -f $_.Name, $lines) " ^
    "}; " ^
    "Write-Host '--------------------------------------------------' -ForegroundColor Gray; " ^
    "Write-Host ('ОБЩЕЕ КОЛИЧЕСТВО СТРОК: ' + $total) -ForegroundColor Green"

echo.
pause
