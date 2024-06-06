document.addEventListener("DOMContentLoaded", function() {
    const images = document.querySelectorAll(".banner img");
    let currentImage = 0;
  
    function showImage(index) {
      images.forEach((img, i) => {
        if (i === index) {
          img.classList.add("active");
        } else {
          img.classList.remove("active");
        }
      });
    }
  
    function nextImage() {
      currentImage = (currentImage + 1) % images.length;
      showImage(currentImage);
    }
  
    setInterval(nextImage, 3000); // Cambia de imagen cada 3 segundos (3000 milisegundos)
  });