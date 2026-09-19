// =========================================================
// AURA — UI-only behaviors (no network / API / SignalR calls)
// =========================================================
(function () {
    "use strict";

    /* -----------------------------------------------------
       Sidebar open / close (mobile)
    ----------------------------------------------------- */
    var sidebar = document.getElementById("sidebar");
    var sidebarToggle = document.getElementById("sidebarToggle");
    var sidebarClose = document.getElementById("sidebarClose");
    var sidebarScrim = document.getElementById("sidebarScrim");

    function openSidebar() {
        sidebar.classList.add("is-open");
        sidebarScrim.style.display = "block";
    }

    function closeSidebar() {
        sidebar.classList.remove("is-open");
        sidebarScrim.style.display = "none";
    }

    if (sidebarToggle) sidebarToggle.addEventListener("click", openSidebar);
    if (sidebarClose) sidebarClose.addEventListener("click", closeSidebar);
    if (sidebarScrim) sidebarScrim.addEventListener("click", closeSidebar);

    /* -----------------------------------------------------
       Model selector dropdown
    ----------------------------------------------------- */
    var modelSelector = document.getElementById("modelSelector");
    var modelTrigger = document.getElementById("modelSelectorTrigger");
    var modelDropdown = document.getElementById("modelDropdown");
    var selectedModelName = document.getElementById("selectedModelName");

    function toggleModelDropdown(forceState) {
        var isOpen = typeof forceState === "boolean" ? forceState : !modelSelector.classList.contains("is-open");
        modelSelector.classList.toggle("is-open", isOpen);
        modelTrigger.setAttribute("aria-expanded", String(isOpen));
    }

    if (modelTrigger) {
        modelTrigger.addEventListener("click", function (e) {
            e.stopPropagation();
            toggleModelDropdown();
        });
    }

    if (modelDropdown) {
        modelDropdown.querySelectorAll(".model-option").forEach(function (option) {
            option.addEventListener("click", function () {
                modelDropdown.querySelectorAll(".model-option").forEach(function (opt) {
                    opt.classList.remove("is-selected");
                    opt.setAttribute("aria-selected", "false");
                });
                option.classList.add("is-selected");
                option.setAttribute("aria-selected", "true");

                var modelName = option.getAttribute("data-model");
                var dotType = option.getAttribute("data-dot");

                selectedModelName.textContent = modelName;

                var triggerDot = modelTrigger.querySelector(".model-dot");
                triggerDot.className = "model-dot model-dot--" + dotType;

                toggleModelDropdown(false);
            });
        });
    }

    // Close dropdown when clicking outside
    document.addEventListener("click", function (e) {
        if (modelSelector && !modelSelector.contains(e.target)) {
            toggleModelDropdown(false);
        }
    });

    // Close dropdown on Escape
    document.addEventListener("keydown", function (e) {
        if (e.key === "Escape") {
            toggleModelDropdown(false);
        }
    });

    /* -----------------------------------------------------
       Composer: textarea auto-grow + send button state
    ----------------------------------------------------- */
    var messageInput = document.getElementById("messageInput");
    var sendBtn = document.getElementById("sendBtn");

    function autoGrow() {
        messageInput.style.height = "auto";
        messageInput.style.height = Math.min(messageInput.scrollHeight, 160) + "px";
    }

    function updateSendState() {
        var hasText = messageInput.value.trim().length > 0;
        sendBtn.disabled = !hasText;
    }

    if (messageInput) {
        messageInput.addEventListener("input", function () {
            autoGrow();
            updateSendState();
        });

        // Enter to "send" (UI only), Shift+Enter for newline
        messageInput.addEventListener("keydown", function (e) {
            if (e.key === "Enter" && !e.shiftKey) {
                e.preventDefault();
                if (sendBtn && !sendBtn.disabled) {
                    sendBtn.click();
                }
            }
        });
    }

    // Suggestion cards drop their prompt text into the composer (UI only)
    document.querySelectorAll(".suggestion-card").forEach(function (card) {
        card.addEventListener("click", function () {
            var prompt = card.getAttribute("data-prompt") || "";
            if (messageInput) {
                messageInput.value = prompt;
                autoGrow();
                updateSendState();
                messageInput.focus();
            }
        });
    });

    /* -----------------------------------------------------
       Code block copy button (UI only — copies rendered text)
    ----------------------------------------------------- */
    document.querySelectorAll(".code-copy-btn").forEach(function (btn) {
        btn.addEventListener("click", function () {
            var codeBlock = btn.closest(".code-block");
            var codeText = codeBlock ? codeBlock.querySelector("code").textContent : "";
            if (navigator.clipboard && codeText) {
                navigator.clipboard.writeText(codeText).catch(function () { });
            }
            var original = btn.textContent;
            btn.textContent = "Kopyalandı";
            setTimeout(function () { btn.textContent = original; }, 1500);
        });
    });

    /* -----------------------------------------------------
       Sidebar conversation search (client-side filter, UI only)
    ----------------------------------------------------- */
    var conversationSearch = document.getElementById("conversationSearch");
    if (conversationSearch) {
        conversationSearch.addEventListener("input", function () {
            var query = conversationSearch.value.trim().toLowerCase();
            document.querySelectorAll(".conversation-item").forEach(function (item) {
                var text = item.textContent.trim().toLowerCase();
                item.style.display = text.indexOf(query) !== -1 ? "" : "none";
            });
        });
    }
})();