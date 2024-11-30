import { ReportHandler } from 'web-vitals';  // Az `onPerfEntry` típusának importálása

const reportWebVitals = (onPerfEntry: ReportHandler): void => {  // Típus hozzáadása
  if (onPerfEntry && onPerfEntry instanceof Function) {
    import('web-vitals').then(({ getCLS, getFID, getFCP, getLCP, getTTFB }) => {
      getCLS(onPerfEntry);
      getFID(onPerfEntry);
      getFCP(onPerfEntry);
      getLCP(onPerfEntry);
      getTTFB(onPerfEntry);
    });
  }
};

export default reportWebVitals;