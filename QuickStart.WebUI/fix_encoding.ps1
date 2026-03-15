$replacements = @{
    "Ã§" = "ç"
    "Ã‡" = "Ç"
    "ÄŸ" = "ğ"
    "Äž" = "Ğ"
    "Ä±" = "ı"
    "Ä°" = "İ"
    "Ã¶" = "ö"
    "Ã–" = "Ö"
    "ÅŸ" = "ş"
    "Åž" = "Ş"
    "Ã¼" = "ü"
    "Ãœ" = "Ü"
    "Ä°" = "İ"
    "â€™" = "'"
    "AÃ§Ä±klama" = "Açıklama"
    "YÃ¶netimi" = "Yönetimi"
    "MÃ¼ÅŸteriler" = "Müşteriler"
    "GÃ¶rsel" = "Görsel"
    "Ä°Ã§erik" = "İçerik"
    "Ä°Ã§eriÄŸi" = "İçeriği"
    "TÃ¼r" = "Tür"
    "BugÃ¼n" = "Bugün"
    "Ã¶n" = "ön"
}

$files = Get-ChildItem -Path "c:\Users\lunap\OneDrive\Masaüstü\MyProjects\QuickStart\QuickStart\QuickStart.WebUI\Views" -Include *.cshtml -Recurse

foreach ($file in $files) {
    if ($file.FullName -match "\\obj\\" -or $file.FullName -match "\\bin\\") { continue }
    
    $content = [System.IO.File]::ReadAllText($file.FullName, [System.Text.Encoding]::UTF8)
    $modified = $false
    
    foreach ($key in $replacements.Keys) {
        if ($content.Contains($key)) {
            $content = $content.Replace($key, $replacements[$key])
            $modified = $true
        }
    }
    
    if ($modified) {
        [System.IO.File]::WriteAllText($file.FullName, $content, [System.Text.Encoding]::UTF8)
        Write-Host "Fixed: $($file.Name)"
    }
}
Write-Host "Done Replacement."
