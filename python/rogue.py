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
    
    ag.hotkey('ctrl', 'shift', 'c')
    
    cb.OpenClipboard()
    data = cb.GetClipboardData()
    cb.CloseClipboard()
    
    fr = 0
    to = 119
    amount = 120
    f = open("demo.txt", "w")
    for i in range(23):
        f.write(data[fr:to] + '\n')
        fr = to + 1
        to += amount
    f.close()
    
if __name__ == "__main__":
    main()