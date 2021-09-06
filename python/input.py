import pyautogui as ag
import window, refresh

def input(key):
    win = window.getWindow()
    ag.press(key)
    refresh.extract(win)