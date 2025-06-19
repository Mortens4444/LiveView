using Database.Interfaces;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Dto;
using LiveView.Enums;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Mtf.Windows.Forms.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class BaseDisplayPresenter : BasePresenter, IDisplayPresenter
    {
        private readonly DisplayManager displayManager;
        private static readonly Pen blackPen;
        private static readonly Pen bluePen;
        private static readonly SolidBrush cornflowerBlueBrush;
        private static readonly SolidBrush lightBlueBrush;
        private static readonly SolidBrush darkGreenBrush;
        private static readonly SolidBrush grayBrush;
        private static readonly SolidBrush darkGrayBrush;
        private static readonly SolidBrush lightGreenBrush;
        private static readonly SolidBrush lightGoldenrodYellowBrush;
        private static readonly SolidBrush darkGoldenrodBrush;
        private static readonly SolidBrush silverBrush;
        private static readonly SolidBrush darkSlateBlueBrush;

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

        public BaseDisplayPresenter(ControlCenterPresenterDependencies dependencies)
            : base(dependencies)
        {
            displayManager = dependencies.DisplayManager;
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
            var displayDimensions = displayManager.GetScreensBounds();
            var diminutive = displayManager.GetScaleFactor(displayDimensions.Bounds, drawnSize);
            WinAPI.GetCursorPos(out var point);
            var mouseLeft = (int)(displayDimensions.Bounds.Left + point.X / diminutive + DisplayManager.FrameWidth / 2 + 1);
            var mouseTop = (int)(displayDimensions.Bounds.Top + point.Y / diminutive + DisplayManager.FrameWidth / 2 + 1);
            return new Point(mouseLeft + displayDimensions.Location.X, mouseTop + displayDimensions.Location.Y);
        }

        public Dictionary<string, Rectangle> GetScaledDisplayBounds(List<DisplayDto> displays, Size size)
        {
            return displayManager.GetScaledDisplayBounds(displays, size);
        }

        public List<SequenceEnvironment> GetSequenceEnvironments(DisplayDto display)
        {
            var result = new List<SequenceEnvironment>();
            foreach (var sequenceProcess in Globals.SequenceProcesses)
            {
                if (display.Id == sequenceProcess.Value.GetDisplayId())
                {
                    var closeButton = new Button
                    {
                        Anchor = AnchorStyles.Top | AnchorStyles.Right,
                        BackColor = SystemColors.Control,
                        Image = Properties.Resources.btn_CloseSequenceApplications_Image,
                        Margin = new Padding(4, 3, 4, 3),
                        Name = $"btnCloseSequence{sequenceProcess.Value.SequenceId}OnDisplay{sequenceProcess.Value.GetDisplayId()}",
                        Size = new Size(21, 21),
                        TabIndex = 0,
                        UseVisualStyleBackColor = false
                    };
                    closeButton.Click += (object sender, EventArgs e) =>
                    {
                        Globals.Server.SendMessageToClient(sequenceProcess.Value.SequenceSocket, NetworkCommand.Close.ToString(), true);
                        Globals.SequenceProcesses.TryRemove(sequenceProcess.Key, out _);
                        var button = sender as Button;
                        button.SafeDispose();
                    };
                    
                    result.Add(new SequenceEnvironment
                    {
                        Display = display,
                        SequenceId = sequenceProcess.Value.SequenceId.Value,
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

                throw new NotSupportedException($"Remote display drawing tools ({displayDrawingTools}) are not supported yet.");
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

            throw new NotSupportedException($"Display drawing tools ({displayDrawingTools}) are not supported yet.");
        }
    }
}
