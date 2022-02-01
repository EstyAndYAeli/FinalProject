# Main.py
import time
import datetime

import cv2
import numpy as np
import os

import pytz
import win32pipe, win32file
import DetectChars
import DetectPlates
import PossiblePlate
import ctypes
import pyodbc

SCALAR_BLACK = (0.0, 0.0, 0.0)
SCALAR_WHITE = (255.0, 255.0, 255.0)
SCALAR_YELLOW = (0.0, 255.0, 255.0)
SCALAR_GREEN = (0.0, 255.0, 0.0)
SCALAR_RED = (0.0, 0.0, 255.0)

showSteps = False
visualize = True


def main():
    cnxn = pyodbc.connect(r'Driver=SQL Server;Server=srv2\pupils;Database=auto_parking;Trusted_Connection=yes;')
    cursor = cnxn.cursor()
    cursor.execute("SELECT back_digits FROM credit_details")
    while 1:
        row = cursor.fetchone()
        if not row:
            break
        print(row)


    count = cursor.execute("""INSERT INTO parking_history (costomer_id, 
    first_name,last_name,phone_number,email,payment_id,CostumerId) VALUES (1,1,1,1,1,1,1)""",
                           ).rowcount
    cnxn.commit()
    print('Rows inserted: ' + str(count))
    cnxn.close()
    # Some other example server values are
    # server = 'localhost\sqlexpress' # for a named instance
    # server = 'myserver,port' # to specify an alternate port
    # server = 'tcp:myserver.database.windows.net'
    # server = "srv2\\pupils"
    # database = 'auto_parking'
    # username = 'MBYDOMAIN/212039275'
    # password = ''
    # cnxn = pyodbc.connect(
    #     'DRIVER={ODBC Driver 17 for SQL Server};SERVER=' + server + ';DATABASE=' + database + ';UID=' + username + ';PWD=' + password)
    # cursor = cnxn.cursor()
    #
    # # Sample select query
    # cursor.execute("SELECT @@car;")
    # row = cursor.fetchone()
    # while row:
    #     print(row[0])
    #     row = cursor.fetchone()


#     file = open("report.csv", "w")
#
#     blnKNNTrainingSuccessful = DetectChars.loadKNNDataAndTrainKNN()  # attempt KNN training
#
#     if blnKNNTrainingSuccessful == False:  # if KNN training was not successful
#         print("\nerror: KNN traning was not successful\n")  # show error message
#         return  # and exit program
#     # end if
#
#     video_input = "video1.mp4"
#     print(video_input)
#     cap = cv2.VideoCapture(video_input)
#     idx = 0
#
#     while True:
#         # reads frames from a video
#         ret, imgOriginalScene = cap.read()
#         idx += 1
#
#         # imgOriginalScene  = cv2.imread(video_feed(video_input))  # open image
#
#         if not ret:
#             break
#             # end if
#
#         listOfPossiblePlates = DetectPlates.detectPlatesInScene(imgOriginalScene)  # detect plates
#         listOfPossiblePlates = DetectChars.detectCharsInPlates(listOfPossiblePlates)  # detect chars in plates
#
#         # cv2.imshow("imgOriginalScene", imgOriginalScene)            # show scene image
#
#         if len(listOfPossiblePlates) != 0:  # if no plates were found
#
#             listOfPossiblePlates.sort(key=lambda possiblePlate: len(possiblePlate.strChars), reverse=True)
#
#             # suppose the plate with the most recognized chars (the first plate in sorted by string length descending order) is the actual plate
#             licPlate = listOfPossiblePlates[0]
#
#             # cv2.imshow("imgPlate", licPlate.imgPlate)           # show crop of plate and threshold of plate
#             # cv2.imshow("imgThresh", licPlate.imgThresh)
#
#             file.write(f"{idx},{licPlate.strChars}\n")
#             print(f"{idx},{licPlate.strChars}")
#             # if len(licPlate.strChars) == 0:                     # if no chars were found in the plate
#             #   print("\nno characters were detected\n\n")  # show message
#             # return                                          # and exit program
#             # end if
#             if visualize:
#                 drawRedRectangleAroundPlate(imgOriginalScene, licPlate)  # draw red rectangle around plate
#                 writeLicensePlateCharsOnImage(imgOriginalScene, licPlate)  # write license plate text on the image
#
#                 cv2.imshow("imgOriginalScene", imgOriginalScene)  # re-show scene image
#                 cv2.waitKey(1)
#         else:
#             file.write(f"{idx},-\n")
#             print(f"{idx},-")
#     file.close()
#     # import ctypes
#     # str = os.system("csc M:\\new-Auto-Parking\\server c#\\Lesson_1\\Program.cs")
#     #
#     # a = ctypes.cdll.LoadLibrary(str)
#     # a.add(3, 5)
#
#
# def drawRedRectangleAroundPlate(imgOriginalScene, licPlate):
#     p2fRectPoints1 = cv2.boxPoints(licPlate.rrLocationOfPlateInScene)  # get 4 vertices of rotated rect
#     p2fRectPoints = [[0, 0], [0, 0], [0, 0], [0, 0]]
#
#     for i in range(4):
#         p2fRectPoints[i][0] = int(p2fRectPoints1[i][0])
#         p2fRectPoints[i][1] = int(p2fRectPoints1[i][1])
#
#     cv2.line(imgOriginalScene, tuple(p2fRectPoints[0]), tuple(p2fRectPoints[1]), SCALAR_RED, 2)  # draw 4 red lines
#     cv2.line(imgOriginalScene, tuple(p2fRectPoints[1]), tuple(p2fRectPoints[2]), SCALAR_RED, 2)
#     cv2.line(imgOriginalScene, tuple(p2fRectPoints[2]), tuple(p2fRectPoints[3]), SCALAR_RED, 2)
#     cv2.line(imgOriginalScene, tuple(p2fRectPoints[3]), tuple(p2fRectPoints[0]), SCALAR_RED, 2)
#
#
# def writeLicensePlateCharsOnImage(imgOriginalScene, licPlate):
#     ptCenterOfTextAreaX = 0  # this will be the center of the area the text will be written to
#     ptCenterOfTextAreaY = 0
#
#     ptLowerLeftTextOriginX = 0  # this will be the bottom left of the area that the text will be written to
#     ptLowerLeftTextOriginY = 0
#
#     sceneHeight, sceneWidth, sceneNumChannels = imgOriginalScene.shape
#     plateHeight, plateWidth, plateNumChannels = licPlate.imgPlate.shape
#
#     intFontFace = cv2.FONT_HERSHEY_SIMPLEX  # choose a plain jane font
#     fltFontScale = float(plateHeight) / 30.0  # base font scale on height of plate area
#     intFontThickness = int(round(fltFontScale * 1.5))  # base font thickness on font scale
#
#     textSize, baseline = cv2.getTextSize(licPlate.strChars, intFontFace, fltFontScale,
#                                          intFontThickness)  # call getTextSize
#
#     ((intPlateCenterX, intPlateCenterY), (intPlateWidth, intPlateHeight),
#      fltCorrectionAngleInDeg) = licPlate.rrLocationOfPlateInScene
#
#     intPlateCenterX = int(intPlateCenterX)  # make sure center is an integer
#     intPlateCenterY = int(intPlateCenterY)
#
#     ptCenterOfTextAreaX = int(intPlateCenterX)  # the horizontal location of the text area is the same as the plate
#
#     if intPlateCenterY < (sceneHeight * 0.75):  # if the license plate is in the upper 3/4 of the image
#         ptCenterOfTextAreaY = int(round(intPlateCenterY)) + int(
#             round(plateHeight * 1.6))  # write the chars in below the plate
#     else:  # else if the license plate is in the lower 1/4 of the image
#         ptCenterOfTextAreaY = int(round(intPlateCenterY)) - int(round(plateHeight * 1.6))
#     # end if
#
#     textSizeWidth, textSizeHeight = textSize
#
#     ptLowerLeftTextOriginX = int(ptCenterOfTextAreaX - (textSizeWidth / 2))
#     ptLowerLeftTextOriginY = int(ptCenterOfTextAreaY + (textSizeHeight / 2))
#
#     # write the text on the image
#     cv2.putText(imgOriginalScene, licPlate.strChars, (ptLowerLeftTextOriginX, ptLowerLeftTextOriginY), intFontFace,
#                 fltFontScale, SCALAR_YELLOW, intFontThickness)
#
#     # making dict while key is num and value is the amount of time is showed
#     import csv
#
#     with open('report.csv') as csv_file:
#         csv_reader = csv.reader(csv_file, delimiter=',')
#         line_count = 0
#         for row in csv_reader:
#             if line_count == 0:
#                 print(f'Column names are {", ".join(row)}')
#                 line_count += 1
#             else:
#                 # print(f'\t{row[0]} works in the {row[1]} department, and was born in {row[2]}.')
#                 line_count += 1
#         print(f'Processed {line_count} lines.')


if __name__ == "__main__":
    main()
