rule xworm : rat
{
    meta:
        description = "xworm detection signature"
        author = "Timo Sarkar <sartimo10@gmail.com>"
        date = "27.03.2024"
        in_the_wild = true

    strings:
        $c2_domain = "jkhdfjksfhdsjkafhsakjfhdjskfhjk.anondns.net"
        $spl = "<Xwormmm>"
        $version = "XWorm V2.1"

    condition:
        $c2_domain or $spl or $version
}
