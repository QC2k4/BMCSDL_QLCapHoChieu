﻿// Hàm xử lý ảnh
function handleImageUpload(inputId, previewId) {
  const input = document.getElementById(inputId);
  const preview = document.getElementById(previewId);
  const uploadBox = input.nextElementSibling.querySelector(".image-upload-box");

  input.addEventListener("change", function (e) {
    const file = e.target.files[0];
    if (file) {
      if (file.size > 5 * 1024 * 1024) {
        alert("Kích thước ảnh không được vượt quá 5MB");
        return;
      }

      if (!file.type.match("image.*")) {
        alert("Vui lòng chọn file ảnh (JPG/PNG)");
        return;
      }

      const reader = new FileReader();

      reader.onload = function (event) {
        preview.src = event.target.result;
        preview.style.display = "block";
        uploadBox.classList.add("has-image");
      };

      reader.readAsDataURL(file);
    }
  });
}

function removeImage(inputId, event) {
  event.stopPropagation();

  const input = document.getElementById(inputId);
  const previewId = inputId + "-preview";
  const preview = document.getElementById(previewId);
  const uploadBox = input.nextElementSibling.querySelector(".image-upload-box");

  input.value = "";
  preview.src = "";
  preview.style.display = "none";
  uploadBox.classList.remove("has-image");
}

function checkStatus() {
  const applicationNumber = document.getElementById("applicationNumber").value;
  const statusResult = document.getElementById("statusResult");
  const statusMessage = document.getElementById("statusMessage");

  if (applicationNumber) {
    statusResult.style.display = "block";
    setTimeout(() => {
      statusMessage.textContent = `Hồ sơ ${applicationNumber}: Đã hoàn thành và sẵn sàng nhận tại cơ quan.`;
    }, 1000);
  } else {
    statusResult.style.display = "block";
    statusMessage.textContent = "Vui lòng nhập mã hồ sơ.";
  }
}

document.addEventListener("DOMContentLoaded", function () {
  handleImageUpload("portrait", "portrait-preview");
  handleImageUpload("cccd-front", "cccd-front-preview");
  handleImageUpload("cccd-back", "cccd-back-preview");
});
