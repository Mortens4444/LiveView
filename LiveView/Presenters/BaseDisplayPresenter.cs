using Database.Interfaces;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Dto;
using LiveView.Enums;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class BaseDisplayPresenter : BasePresenter, IDisplayPresenter
    {
        private readonly DisplayManager displayManager;
        private static Pen blackPen, bluePen;
        private static SolidBrush cornflowerBlueBrush, lightBlueBrush, darkGreenBrush, grayBrush, darkGrayBrush, lightGreenBrush,
            lightGoldenrodYellowBrush, darkGoldenrodBrush, silverBrush, darkSlateBlueBrush;

        static BaseDisplayPresenter()
        {
            blackPen = new Pen(Color.Black, 2);
            bluePen = new Pen(Color.Blue, 2);
            cornflowerBlueBrush = new SolidBrush(Color.CornflowerBlue);
            darkSlateBlueBrush = new SolidBrush(Color.DarkSlateBlue);
            lightBlueBrush = new SolidBrush(Color.LightBlue);
            grayBrush = new SolidBrush(Color.Gray);
            darkGrayBrush = new SolidBrush(Color.DarkGray);
            lightGreenBrush = new SolidBrush(Color.LightGreen);
            darkGreenBrush = new SolidBrush(Color.DarkGreen);
            lightGoldenrodYellowBrush = new SolidBrush(Color.LightGoldenrodYellow);
            darkGoldenrodBrush = new SolidBrush(Color.DarkGoldenrod);
            silverBrush = new SolidBrush(Color.Silver);
        }

        public BaseDisplayPresenter(ControlCenterPresenterDependencies controlCenterPresenterDependencies)
            : base(controlCenterPresenterDependencies.GeneralOptionsRepository, controlCenterPresenterDependencies.FormFactory)
        {
            displayManager = controlCenterPresenterDependencies.DisplayManager;
        }

        public BaseDisplayPresenter(DisplayManager displayManager, IGeneralOptionsRepository generalOptionsRepository, FormFactory formFactory)
            : base(generalOptionsRepository, formFactory)
        {
            this.displayManager = displayManager;
        }

        public void IdentifyDisplays()
        {
            var displays = displayManager.GetAll();
            foreach (var display in displays)
            {
                ShowForm<DisplayDeviceIdentifier>(display);
            }
        }

        public List<DisplayDto> GetDisplays()
        {
            return displayManager.GetAll();
        }

        public Point GetMouseLocation(Size drawnSize)
        {
            var (screenBounds, deltaPoint) = displayManager.GetScreensBounds();
            var diminutive = displayManager.GetScaleFactor(screenBounds, drawnSize);
            var point = new POINT();
            WinAPI.GetCursorPos(out point);
            var mouseLeft = (int)(screenBounds.Left + point.X / diminutive + DisplayManager.FrameWidth / 2 + 1);
            var mouseTop = (int)(screenBounds.Top + point.Y / diminutive + DisplayManager.FrameWidth / 2 + 1);
            return new Point(mouseLeft + deltaPoint.X, mouseTop + deltaPoint.Y);
        }

        public Dictionary<string, Rectangle> GetScaledDisplayBounds(List<DisplayDto> displays, Size size)
        {
            return displayManager.GetScaledDisplayBounds(displays, size);
        }

        public List<SequenceEnvironment> GetSequenceEnvironments(DisplayDto display)
        {
            var result = new List<SequenceEnvironment>();
            foreach (var sequenceProcess in MainPresenter.SequenceProcesses)
            {
                var (socket, processId, sequenceId, displayId) = sequenceProcess.Value;
                if (display.Id == displayId.ToString()) // ToDo: Handle remote display sequences also
                {
                    var closeButton = new Button
                    {
                        Anchor = AnchorStyles.Top | AnchorStyles.Right,
                        BackColor = SystemColors.Control,
                        Image = Properties.Resources.btn_CloseSequenceApplications_Image,
                        Margin = new Padding(4, 3, 4, 3),
                        Name = $"btnCloseSeuence{sequenceId}OnDisplay{displayId}",
                        Size = new Size(21, 21),
                        TabIndex = 0,
                        UseVisualStyleBackColor = false
                    };
                    closeButton.Click += (object sender, EventArgs e) =>
                    {
                        MainPresenter.Server.SendMessageToClient(socket, NetworkCommand.Close.ToString(), true);
                        MainPresenter.SequenceProcesses[sequenceProcess.Key] = (null, 0, 0, 0);
                        var button = sender as Button;
                        button.Parent.Controls.Remove(button);
                        button.Dispose();
                    };
                    
                    result.Add(new SequenceEnvironment
                    {
                        Display = display,
                        SequenceId = sequenceId,
                        CloseButton = closeButton
                    });
                }
            }
            return result;
        }

        public (Pen, SolidBrush) GetDrawingTools(DisplayDto display, DisplayDrawingTools displayDrawingTools)
        {
            if (display.IsRemote)
            {
                if (displayDrawingTools == DisplayDrawingTools.Functions)
                {
                    if (display.CanShowSequence && display.CanShowFullscreen)
                    {
                        return (blackPen, silverBrush);
                    }
                    else if (display.CanShowSequence)
                    {
                        return (blackPen, darkGoldenrodBrush);
                    }
                    else if (display.CanShowFullscreen)
                    {
                        return (blackPen, darkGreenBrush);
                    }

                    return (blackPen, darkGrayBrush);
                }

                if (displayDrawingTools == DisplayDrawingTools.Selected)
                {
                    if (display.Selected)
                    {
                        return (bluePen, darkSlateBlueBrush);
                    }

                    return (blackPen, silverBrush);
                }

                if (displayDrawingTools == DisplayDrawingTools.Fullscreen)
                {
                    if (display.Fullscreen)
                    {
                        return (blackPen, darkGreenBrush);
                    }
                    return (blackPen, silverBrush);
                }

                if (displayDrawingTools == DisplayDrawingTools.Sequence)
                {
                    if (display.Selected)
                    {
                        return (blackPen, darkGreenBrush);
                    }
                    return (blackPen, darkGrayBrush);
                }

                throw new NotImplementedException($"Remoted isplay drawing tools ({displayDrawingTools}) are not implemented.");
            }

            if (displayDrawingTools == DisplayDrawingTools.Functions)
            {
                if (display.CanShowSequence && display.CanShowFullscreen)
                {
                    return (blackPen, lightBlueBrush);
                }
                else if (display.CanShowSequence)
                {
                    return (blackPen, lightGoldenrodYellowBrush);
                }
                else if (display.CanShowFullscreen)
                {
                    return (blackPen, lightGreenBrush);
                }

                return (blackPen, grayBrush);
            }

            if (displayDrawingTools == DisplayDrawingTools.Selected)
            {
                if (display.Selected)
                {
                    return (bluePen, cornflowerBlueBrush);
                }

                return (blackPen, lightBlueBrush);
            }

            if (displayDrawingTools == DisplayDrawingTools.Fullscreen)
            {
                if (display.Fullscreen)
                {
                    return (blackPen, lightGreenBrush);
                }
                return (blackPen, lightBlueBrush);
            }

            if (displayDrawingTools == DisplayDrawingTools.Sequence)
            {
                if (display.Selected)
                {
                    return (blackPen, lightGreenBrush);
                }
                return (blackPen, grayBrush);
            }

            throw new NotImplementedException($"Display drawing tools ({displayDrawingTools}) are not implemented.");
        }
    }
}
