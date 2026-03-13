$viewsPath = ".\Views"
$files = Get-ChildItem -Path $viewsPath -Filter *.cshtml -Recurse

foreach ($f in $files) {
    $content = [System.IO.File]::ReadAllText($f.FullName, [System.Text.Encoding]::UTF8)
    
    $modified = $false
    
    if ($content -match 'Ã§') { $content = $content.Replace('Ã§', 'ç'); $modified = $true }
    if ($content -match 'Ã‡') { $content = $content.Replace('Ã‡', 'Ç'); $modified = $true }
    if ($content -match 'ÄŸ') { $content = $content.Replace('ÄŸ', 'ğ'); $modified = $true }
    if ($content -match 'Äž') { $content = $content.Replace('Äž', 'Ğ'); $modified = $true }
    if ($content -match 'Ä±') { $content = $content.Replace('Ä±', 'ı'); $modified = $true }
    if ($content -match 'Ä°') { $content = $content.Replace('Ä°', 'İ'); $modified = $true }
    if ($content -match 'Ã¶') { $content = $content.Replace('Ã¶', 'ö'); $modified = $true }
    if ($content -match 'Ã–') { $content = $content.Replace('Ã–', 'Ö'); $modified = $true }
    if ($content -match 'ÅŸ') { $content = $content.Replace('ÅŸ', 'ş'); $modified = $true }
    if ($content -match 'Åž') { $content = $content.Replace('Åž', 'Ş'); $modified = $true }
    if ($content -match 'Ã¼') { $content = $content.Replace('Ã¼', 'ü'); $modified = $true }
    if ($content -match 'Ãœ') { $content = $content.Replace('Ãœ', 'Ü'); $modified = $true }

    if ($modified) {
        [System.IO.File]::WriteAllText($f.FullName, $content, [System.Text.Encoding]::UTF8)
    }
}
