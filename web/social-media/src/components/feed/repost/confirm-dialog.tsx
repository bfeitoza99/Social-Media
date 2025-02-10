"use client";

import { Dialog, DialogTitle, DialogContent, DialogActions, Button } from "@mui/material";

interface ConfirmDialogProps {
  isOpen: boolean;
  onConfirm: () => void;
  onCancel: () => void;
}

const ConfirmDialog: React.FC<ConfirmDialogProps> = ({ isOpen, onConfirm, onCancel }) => {
  return (
    <Dialog
      open={isOpen}
      onClose={onCancel}
      slotProps={{
        paper: {
          sx: {
            backgroundColor: "#18181B", 
            color: "#F3F4F6", 
            borderRadius: "8px",
            padding: "16px",
            minWidth: "320px",
          },
        },
      }}
    >
      <DialogTitle sx={{ color: "#F9FAFB", fontWeight: "bold", fontSize: "18px" }}>
        Confirm Repost
      </DialogTitle>
      <DialogContent>
        <p style={{ color: "#D1D5DB", fontSize: "14px" }}>
          Are you sure you want to repost this publication?
        </p>
      </DialogContent>

      <DialogActions
        sx={{
          padding: "12px",
          borderRadius: "0 0 8px 8px",
          display: "flex",
          justifyContent: "space-between",
        }}
      >
        <Button
          onClick={onCancel}
          sx={{
            color: "#D1D5DB", 
            backgroundColor: "#27272A", 
            "&:hover": { backgroundColor: "#3F3F46" },
            textTransform: "uppercase",
            fontWeight: "bold",
            padding: "8px 16px",
            borderRadius: "6px",
          }}
        >
          Cancel
        </Button>

        <Button
          onClick={onConfirm}
          variant="contained"
          sx={{
            backgroundColor: "#2563EB", 
            color: "#FFFFFF",
            "&:hover": { backgroundColor: "#1E40AF" }, 
            textTransform: "uppercase",
            fontWeight: "bold",
            padding: "8px 16px",
            borderRadius: "6px",
          }}
        >
          Confirm
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default ConfirmDialog;
