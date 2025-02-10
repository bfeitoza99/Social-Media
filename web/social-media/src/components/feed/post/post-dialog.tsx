"use client";

import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
} from "@mui/material";

interface PostModalProps {
  isOpen: boolean;
  onClose: () => void;
  content: string;
  authorNickname: string;
}

const PostModal: React.FC<PostModalProps> = ({
  isOpen,
  onClose,
  content,
  authorNickname,
}) => {
  return (
    <Dialog
      open={isOpen}
      onClose={onClose}
      fullWidth
      maxWidth="md"
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
      <DialogTitle
        sx={{ color: "#F9FAFB", fontWeight: "bold", fontSize: "18px" }}
      >
        {authorNickname}'s Post
      </DialogTitle>
      <DialogContent>
        <p style={{ color: "#D1D5DB", fontSize: "14px" }}>{content}</p>
      </DialogContent>

      <DialogActions
        sx={{
          padding: "12px",
          borderRadius: "0 0 8px 8px",
          display: "flex",
          justifyContent: "flex-end",
        }}
      >
        <Button
          onClick={onClose}
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
          Close
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default PostModal;
