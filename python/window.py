import pygetwindow as gw

def getWindow():
    window = gw.getWindowsWithTitle("rogue.exe")[0]
    window.restore()
    window.activate()
    window.moveTo(0, 0)
    return window