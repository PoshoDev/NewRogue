import pyautogui as ag
import win32clipboard as cb
import window
import pygetwindow as gw

def main():
    extract(window.getWindow())

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
    f = open("data.txt", "w")
    for i in range(24):
        f.write(data[fr:to] + '\n')
        fr = to + 1
        to += amount
    f.close()
    
    win.minimize()
    
if __name__ == "__main__":
    main()