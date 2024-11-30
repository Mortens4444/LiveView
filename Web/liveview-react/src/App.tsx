import React, { useEffect, useRef, useState } from 'react';

const App: React.FC = () => {
  const videoRef = useRef<HTMLVideoElement | null>(null); // Videó elem típusa
  const [hasCamera, setHasCamera] = useState<boolean>(false); // Kamera elérhetősége
  const streamRef = useRef<MediaStream | null>(null); // A stream mentése

  // Kamera stream indítása
  const startCamera = async () => {
    try {
      const stream = await navigator.mediaDevices.getUserMedia({ video: true });
      if (videoRef.current) {
        videoRef.current.srcObject = stream;
      }
      streamRef.current = stream; // Mentjük el a stream-et
      setHasCamera(true);
    } catch (error) {
      console.error("Hiba történt a kamera hozzáférésekor:", error);
      setHasCamera(false);
    }
  };

  // A kamera stream leállítása
  const stopCamera = () => {
    if (streamRef.current) {
      const tracks = streamRef.current.getTracks();
      tracks.forEach(track => track.stop()); // Minden track-et leállítunk
      if (videoRef.current) {
        videoRef.current.srcObject = null; // A stream leválasztása a video elemtől
      }
      setHasCamera(false);
    }
  };

  useEffect(() => {
    startCamera(); // Kamera automatikus indítása

    // Az oldal frissítésének vagy bezárásának figyelése
    const handleBeforeUnload = () => {
      stopCamera(); // A kamera stream leállítása
    };

    // A 'beforeunload' esemény figyelése
    window.addEventListener("beforeunload", handleBeforeUnload);

    return () => {
      window.removeEventListener("beforeunload", handleBeforeUnload);
    };
  }, []);

  return (
    <div style={{ backgroundColor: 'black', height: '100vh', display: 'flex', justifyContent: 'center', alignItems: 'center', flexDirection: 'column' }}>
      <h1>WebRTC Kamera</h1>
      {!hasCamera ? (
        <p>Nem található kamera vagy engedélyezni kell a hozzáférést.</p>
      ) : (
        <video ref={videoRef} autoPlay muted style={{ width: '100%', maxWidth: '600px', border: '2px solid black' }} />
      )}
    </div>
  );
};

export default App;
