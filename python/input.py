import pyautogui as ag
import window, refresh
import sys

win = window.getWindow()
if (sys.argv[1] != ""):
    ag.press(sys.argv[1])
refresh.extract(win)