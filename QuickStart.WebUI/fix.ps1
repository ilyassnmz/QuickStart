Get-ChildItem -Path .\Views -Filter *.cshtml -Recurse | ForEach-Object {
    $c = Get-Content $_.FullName -Raw
    if ($c -match '~/Views/AdminLayout/Index.cshtml') {
        $c = $c -replace '~/Views/AdminLayout/Index.cshtml', '~/Views/Shared/_AdminLayout.cshtml'
        [System.IO.File]::WriteAllText($_.FullName, $c, [System.Text.Encoding]::UTF8)
    }
}
