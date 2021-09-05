import pygetwindow as gw
import pyautogui as ag
import win32clipboard as cb

def main():
    window = gw.getWindowsWithTitle("rogue.exe")[0]
    window.activate()
    window.moveTo(0, 0)

    extract(window)

# Functions
def extract(win):
    win.activate()
    
    off = 42
    st_x = win.left + 8
    st_y = win.top + off + 1
    ed_x = win.width - 8
    ed_y = win.height - 8
    
    ag.moveTo(x=st_x, y=st_y)
    ag.mouseDown()
    ag.moveTo(x=ed_x, y=ed_y)
    ag.mouseUp()
    
    ag.keyDown("ctrl")
    ag.keyDown("shift")
    ag.keyDown("c")
    
    ag.keyUp("control")
    ag.keyUp("shift")
    ag.keyUp("c")
    
    ag.keyUp("shift")
    
    cb.OpenClipboard()
    data = cb.GetClipboardData()
    cb.CloseClipboard()
    fr = 0
    to = 119
    print(data[fr:to] + "n")
    
    fr, to = inc(data, fr, to, 120)
    fr, to = inc(data, fr, to, 120)
    fr, to = inc(data, fr, to, 120)
    fr, to = inc(data, fr, to, 120)
    fr, to = inc(data, fr, to, 120)
    fr, to = inc(data, fr, to, 120)
    
    f = open("demo.txt", "w")
    f.write(data)
    f.close()
    
def inc(data, fr, to, amount):
    fr = to+1
    to += amount
    print(data[fr:to] + "n")
    return fr, to
    
if __name__ == "__main__":
    main()